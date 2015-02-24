using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OneDrive
{
    internal class WrappedHttpClientRequest : Http.IHttpRequest
    {
        private static readonly HttpClientHandler Handler;
        private HttpClient Client { get; set; }

        static WrappedHttpClientRequest()
        {
            Handler = new HttpClientHandler {
                AllowAutoRedirect = false,
                //AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = false
            };
        }

        public WrappedHttpClientRequest(Uri uri)
        {
            Uri = uri;
            Headers = new Dictionary<string, string>();
        }

        public Uri Uri { get; private set; }
        public string Method { get; set; }
        public string Body { get; set; }
        public string ContentType { get; set; }
        public string ContentRange { get; set; }
        public string Accept { get; set; }
        public Dictionary<string, string> Headers {get; private set;}
        private MemoryStream RequestBodyStream {get;set;}

        public async Task<Stream> GetRequestStreamAsync()
        {
            RequestBodyStream = new MemoryStream();
            return RequestBodyStream;
        }

        public async Task<Http.IHttpResponse> GetResponseAsync()
        {
            // Build the StreamContent if necessary
            
            var client = new HttpClient(Handler);
            var message = BuildMessage();

            var response = await client.SendAsync(message);
            return new WrappedHttpClientResponse(response);
        }

        private HttpRequestMessage BuildMessage()
        {
            var message = new HttpRequestMessage();
            switch(Method)
            {
                case ApiConstants.HttpGet:
                    message.Method = HttpMethod.Get;
                    break;
                case ApiConstants.HttpDelete:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiConstants.HttpPost:
                     message.Method = HttpMethod.Post;
                      break;
                case ApiConstants.HttpPut:
                      message.Method = HttpMethod.Put;
                    break;
                case ApiConstants.HttpPatch:
                default:
                    message.Method = HttpMethod.Post;
                    message.Headers.Add("x-http-method-override", Method);
                    break;
            }
            message.Content = GetContent();
            foreach(var header in Headers)
            {
                message.Headers.Add(header.Key, header.Value);
            }

            if (!string.IsNullOrEmpty(Accept))
            {
                message.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Accept));
            }

            message.RequestUri = Uri;
            return message;
        }

        private HttpContent GetContent()
        {
            HttpContent content = null;
            if(null != RequestBodyStream)
            {
                RequestBodyStream.Seek(0, SeekOrigin.Begin);
                content = new StreamContent(RequestBodyStream);
                if (null != ContentType)
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);
                if (null != ContentRange)
                {
                    var header = OneDrive.ContentRange.FromContentRangeHeaderValue(ContentRange);
                    content.Headers.ContentRange = new System.Net.Http.Headers.ContentRangeHeaderValue(header.FirstByteIndex, header.LastByteIndex, header.TotalLengthBytes);
                }
            }

            return content;
        }
    }

    internal class WrappedHttpClientResponse : Http.IHttpResponse
    {
        private HttpResponseMessage ResponseMessage { get; set; }
        public WrappedHttpClientResponse(HttpResponseMessage response)
        {
            ResponseMessage = response;
        }

        public Uri Uri { get { return ResponseMessage.RequestMessage.RequestUri; } }

        public System.Net.HttpStatusCode StatusCode { get { return ResponseMessage.StatusCode; } }

        public string StatusDescription { get { return ResponseMessage.ReasonPhrase; } }

        public string ContentType 
        {
            get 
            {
                if (null != ResponseMessage.Content
                    && null != ResponseMessage.Content.Headers
                    && null != ResponseMessage.Content.Headers.ContentType)
                {
                    return ResponseMessage.Content.Headers.ContentType.MediaType;
                }

                return null;
            } 
        }

        public IReadOnlyDictionary<string, string> Headers
        {
            get
            {
                var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (var head in ResponseMessage.Headers)
                {
                    headers[head.Key] = head.Value.First();
                }
                return headers;
            }
        }

        public async Task<Stream> GetResponseStreamAsync() 
        {
            return await ResponseMessage.Content.ReadAsStreamAsync();
        }
    }
}
