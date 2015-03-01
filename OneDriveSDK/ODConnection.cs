using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OneDrive
{
    public partial class ODConnection
    {
        #region Private Constants
        public const long MaxRegularUploadSize = 60 * 1024 * 1024;  // 60 MB
        private const string UrlSeperator = "/";
        #endregion

        #region Properties
        internal IAuthenticationInfo Authentication { get; private set; }

        public string RootUrl { get; private set; }
        #endregion

        #region Constructors

        public ODConnection(string rootUrl, IAuthenticationInfo auth)
        {
            HttpRequestFactory = new Http.HttpFactoryDefault();
            RootUrl = rootUrl;
            Authentication = auth;
        }

        #endregion

        #region Helper Methods
        internal async Task<T> DataModelForRequest<T>(Uri uri, string httpMethod) where T : ODDataModel
        {
            var request = await CreateHttpRequestAsync(uri, httpMethod);
            return await DataModelForRequest<T>(request);
        }

        private async Task<T> DataModelForRequest<T>(Http.IHttpRequest request) where T : ODDataModel
        {
            var response = await GetHttpResponseAsync(request);
            return await response.ConvertToDataModel<T>();
        }

        private async Task<ODAsyncTask> AsyncTaskResultForRequest(Http.IHttpRequest request, Uri requestUri)
        {
            var response = await GetHttpResponseAsync(request);
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                var sourceUrl = new Uri(response.Headers[ApiConstants.LocationHeaderName]);
                var jobStatus = new ODAsyncTask { StatusUri = sourceUrl, RequestUri = requestUri };
                await RefreshAsyncTaskStatus(jobStatus);
                return jobStatus;
            }
            else
            {
                var exception = await response.ToException();
                throw exception;
            }
        }

        internal async Task RefreshAsyncTaskStatus(ODAsyncTask task)
        {
            if (null == task) throw new ArgumentNullException("task");
            if (null == task.StatusUri) throw new ArgumentException("task cannot have a null source URL");

            var request = await CreateHttpRequestAsync(task.StatusUri, ApiConstants.HttpGet);
            var response = await GetHttpResponseAsync(request);
            if (response.ContentType != null)
            {
                var newStatus = await response.ConvertToDataModel<ODAsyncTaskStatus>();
                task.Status = newStatus;
            }
            else if (response.StatusCode == HttpStatusCode.SeeOther)
            {
                if (task.Status != null)
                {
                    task.Status.PercentComplete = 100;
                    task.Status.Status = AsyncJobStatus.Complete;
                }

                // Create a request to get the new item
                Uri newUrl = new Uri(response.Headers[ApiConstants.LocationHeaderName]);
                var itemRequest = await CreateHttpRequestAsync(newUrl, ApiConstants.HttpGet);
                task.FinishedItem = await DataModelForRequest<ODItem>(itemRequest);
            }
        }

        private static async Task<Http.IHttpResponse> GetHttpResponseAsync(Http.IHttpRequest request)
        {
            Http.IHttpResponse response;
            try
            {
                response = await request.GetResponseAsync();
            }
            catch (Exception ex)
            {
                throw new ODException(ex.Message, ex);
            }

            switch(response.StatusCode.ToHttpResponseType())
            {
                case HttpResponseType.ServerError:
                case HttpResponseType.ClientError:
                    var exception = await response.ToException();
                    throw exception;
            }


            return response;
        }
        
        private async Task AddCommonRequestHeaders(Http.IHttpRequest request)
        {
            // Check to see if authentication is still valid
            if (Authentication.TokenExpiration < DateTimeOffset.Now.AddMinutes(5))
            {
                await Authentication.RefreshAccessTokenAsync();
            }
            
            request.Headers["Authorization"] = Authentication.AuthorizationHeaderValue;
            request.Accept = ApiConstants.ContentTypeJson;
        }

        /// <summary>
        /// Serializes the body object and writes in into the request stream of the HttpWebRequest instance.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task SerializeObjectToRequestBody(object obj, Http.IHttpRequest request)
        {
            request.ContentType = ApiConstants.ContentTypeJson;

            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var bodyText = Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);

            var requestStream = await request.GetRequestStreamAsync();
            var writer = new StreamWriter(requestStream, Encoding.UTF8, 1024 * 1024, true);
            await writer.WriteAsync(bodyText);
            await writer.FlushAsync();
        }

        private async Task<ODItem> UploadToUrl(Stream sourceFileStream, ItemUploadOptions options, long localItemSize, Uri serviceUri)
        {
            var request = await CreateHttpRequestAsync(serviceUri, ApiConstants.HttpPut);
            request.ContentType = ApiConstants.ContentTypeBinary;

            options.ModifyRequest(request);

            var requestStream = await request.GetRequestStreamAsync();
            await sourceFileStream.CopyWithProgressAsync(requestStream, options.ProgressReporter, localItemSize);

            return await GetResponseDataModel<ODItem>(request);
        }

        private async Task<T> GetResponseDataModel<T>(Http.IHttpRequest request) where T: ODDataModel
        {
            var httpResponse = await GetHttpResponseAsync(request);
            if (null != httpResponse && 
                (httpResponse.StatusCode == HttpStatusCode.Created 
                || httpResponse.StatusCode == HttpStatusCode.OK))
            {
                return await httpResponse.ConvertToDataModel<T>();
            }

            return null;
        }

        private async Task<Http.IHttpRequest> CreateHttpRequestAsync(Uri uri, string httpMethod)
        {
            var request = HttpRequestFactory.CreateHttpRequest(uri);
            request.Method = httpMethod;
            await AddCommonRequestHeaders(request);
            return request;
        }

        public static ODItemReference ItemReferenceForSpecialFolder(string specialFolderName, string relativePath = null, string driveid = null)
        {
            ODItemReference reference = new ODItemReference { DriveId = driveid };

            var path = new StringBuilder();
            if (string.IsNullOrEmpty(driveid))
                path.Append("/drive/special/");
            else
                path.AppendFormat("/drives/{0}/special/", driveid);

            path.Append(specialFolderName);

            if (!string.IsNullOrEmpty(relativePath))
            {
                path.Append("/:");
                path.AppendFormat(relativePath);
            }
            reference.Path = path.ToString();
            return reference;
        }

        /// <summary>
        /// Crates an item reference for a path (and optionally driveId) relative to the root of the user's OneDrive.
        /// 
        /// For example, to reference a file "bar.txt" in folder "Foo" in the root of a drive you would set drivePath to "/Foo/bar.txt".
        /// </summary>
        /// <param name="drivePath"></param>
        /// <param name="driveId"></param>
        /// <returns></returns>
        public static ODItemReference ItemReferenceForDrivePath(string drivePath, string driveId = null)
        {
            if (null == drivePath)
                throw new ArgumentNullException("drivePath", "drivePath cannot be null");

            if (drivePath.StartsWith("/", StringComparison.Ordinal))
                drivePath = drivePath.Substring(1);

            if (driveId == null)
                return new ODItemReference { Path = string.Concat("/drive/root:/", drivePath) };
            else
                return new ODItemReference { DriveId = driveId, Path = string.Concat("/drives/", driveId, "/root:/", drivePath) };
        }

        public static ODItemReference ItemReferenceForItemId(string itemId, string driveId = null)
        {
            return new ODItemReference { Id = itemId, DriveId = driveId };
        }

        /// <summary>
        /// Return the URL for the service based on an item reference, navigation path (optional) and query string (optional)
        /// </summary>
        /// <param name="itemReference"></param>
        /// <param name="navigationPath"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        private Uri UriForItemReference(ODItemReference itemReference, string navigationPath = null, QueryStringBuilder queryString = null)
        {
            // RootUrl = "https://api.onedrive.com/v1.0"
            StringBuilder url = new StringBuilder(RootUrl);

            if (!string.IsNullOrEmpty(itemReference.Id))
            {
                if  (!string.IsNullOrEmpty(itemReference.DriveId)) 
                {
                    url.AppendFormat("/drives/{0}", itemReference.DriveId);
                }
                else
                { 
                    url.AppendFormat("/drive");
                }

                url.AppendFormat("/items/{0}", itemReference.Id);
            }
            else if (!string.IsNullOrEmpty(itemReference.Path))
            {
                if (!itemReference.Path.StartsWith("/drive", StringComparison.Ordinal))
                    throw new ArgumentException("Invalid ODItemReference: Path doesn't start with \"/drive\" or \"/drives\".");

                url.Append(itemReference.Path);
                if (itemReference.Path.OccurrencesOfCharacter(':') == 1)
                {
                    // Make sure we terminate the path escape so we can add a navigation property if necessary
                    url.Append(":");
                }
            }
            else
            {
                // Just address the drive if both path & id are null.
                if (!string.IsNullOrEmpty(itemReference.DriveId))
                {
                    url.AppendFormat("/drives/{0}", itemReference.DriveId);
                }
                else
                {
                    url.AppendFormat("/drive");
                }
            }

            if (!string.IsNullOrEmpty(navigationPath))
            {
                
                if (url[url.Length - 1] != '/')
                    url.AppendFormat("/");
                url.Append(navigationPath);
            }

            UriBuilder builder = new UriBuilder(url.ToString());
            if (null != queryString && queryString.HasKeys)
            {
                builder.Query = queryString.ToString();
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine("URL: " + builder.Uri);
#endif
            return builder.Uri;
        }

        /// <summary>
        /// Convert a set of OData query string options into a real query string
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        private QueryStringBuilder ODataOptionsToQueryString(RetrievalOptions options)
        {
            var builder = new QueryStringBuilder();
            foreach (var o in options.ToOptions())
            {
                builder.Add(o.Name, o.ToValue());
            }
            return builder;
        }


        private void AddAsyncHeaders(Http.IHttpRequest request)
        {
            request.Headers[ApiConstants.PreferHeaderName] = ApiConstants.PreferAsyncResponseValue;
        }

        private async Task<ODItem> StartLargeFileTransfer(Uri createSessionUri, Stream sourceFileStream, ItemUploadOptions options)
        {
            var request = await CreateHttpRequestAsync(createSessionUri, ApiConstants.HttpPost);
            
            //object requestBody = new { item = new ODUploadSessionDescriptor { FilenameConflictBehavior = options.NameConflict } };
            //await SerializeObjectToRequestBody(requestBody, request);
            var response = await DataModelForRequest<ODUploadSession>(request);

            var uploader = new LargeFileUploader(this, response, sourceFileStream, options);
            var item = await uploader.UploadFileStream();
            return item;
        }


        #endregion


        internal async Task<ODDataModel> PutFileFragment(Uri serviceUri, byte[] fragment, ContentRange requestRange)
        {
            var request = await CreateHttpRequestAsync(serviceUri, ApiConstants.HttpPut);
            request.ContentRange = requestRange.ToContentRangeHeaderValue();

            var stream = await request.GetRequestStreamAsync();
            await stream.WriteAsync(fragment, 0, (int)requestRange.BytesInRange);

            var response = await request.GetResponseAsync();
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return await response.ConvertToDataModel<ODUploadSession>();
            }
            else if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            {
                return await response.ConvertToDataModel<ODItem>();
            }
            else
            {
                var exception = await response.ToException();
                throw exception;
            }
        }
    }

    enum PathNamespace
    {
        ItemId,
        Path,
        KnownFolder
    }
}
