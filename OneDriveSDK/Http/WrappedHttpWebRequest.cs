using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OneDrive
{
    internal class WrappedHttpWebRequest : OneDrive.Http.IHttpRequest
    {
        private HttpWebRequest InternalRequest { get; set; }

        public WrappedHttpWebRequest(Uri uri)
        {
            Uri = uri;
            Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public Uri Uri {get; private set;}
        public string Method {get;set;}
        public string Body {get;set;}
        public string ContentType {get;set;}
        public string ContentRange { get; set; }
        public string Accept { get; set; }
        public Dictionary<string, string> Headers {get; private set;}

        public async Task<Stream> GetRequestStreamAsync()
        {
            CreateRequest();
            return await InternalRequest.GetRequestStreamAsync();
        }

        public async Task<Http.IHttpResponse> GetResponseAsync()
        {
            CreateRequest();
            var response = await InternalRequest.GetResponseAsync();
            return new WrappedHttpWebResponse((HttpWebResponse)response);
        }

        private void CreateRequest()
        {
            if (null == InternalRequest)
            {
                InternalRequest = WebRequest.CreateHttp(Uri);
                InternalRequest.Method = Method;
                InternalRequest.ContentType = ContentType;
                InternalRequest.Accept = Accept;
                foreach (var header in Headers)
                {
                    InternalRequest.Headers[header.Key] = header.Value;
                }
                if (null != ContentRange)
                {
                    InternalRequest.Headers[ApiConstants.ContentRangeHeaderName] = ContentRange;
                }
            }
        }
    }

    internal class WrappedHttpWebResponse : OneDrive.Http.IHttpResponse
    {
        private HttpWebResponse InternalResponse { get; set; }

        internal WrappedHttpWebResponse(HttpWebResponse response)
        {
            InternalResponse = response;
        }

        public Uri Uri { get { return InternalResponse.ResponseUri; } }

        public HttpStatusCode StatusCode { get { return InternalResponse.StatusCode; } }

        public string StatusDescription { get { return InternalResponse.StatusDescription; } }

        public string ContentType { get { return InternalResponse.ContentType; } }

        public IReadOnlyDictionary<string, string> Headers
        {
            get
            {
                var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var head in InternalResponse.Headers.AllKeys)
                {
                    headers[head] = InternalResponse.Headers[head];
                }

                return headers;
            }
        }

        public async Task<Stream> GetResponseStreamAsync() 
        {
            return InternalResponse.GetResponseStream();
        }
    }
}
