using System;

namespace OneDrive.Http
{
    internal class HttpFactoryDefault : IHttpFactory
    {
        public IHttpRequest CreateHttpRequest(Uri uri)
        {
            return new WrappedHttpClientRequest(uri);
        }
    }
}
