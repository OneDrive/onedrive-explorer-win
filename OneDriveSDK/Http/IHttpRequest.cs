using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OneDrive.Http
{
    public interface IHttpRequest
    {
        Uri Uri { get; }
        string Method { get; set; }
        string ContentType { get; set; }
        string ContentRange { get; set; }
        string Accept { get; set; }
        Dictionary<string, string> Headers { get; }

        Task<Stream> GetRequestStreamAsync();

        Task<IHttpResponse> GetResponseAsync();
    }

    public interface IHttpResponse
    {
        Uri Uri { get; }
        HttpStatusCode StatusCode { get; }
        string StatusDescription { get; }
        string ContentType { get; }
        IReadOnlyDictionary<string, string> Headers { get; }

        Task<Stream> GetResponseStreamAsync();
    }

    public interface IHttpFactory
    {
        IHttpRequest CreateHttpRequest(Uri uri);
    }
}
