using System;
using System.IO;
using System.Threading.Tasks;

namespace OneDrive
{
    internal static class HttpExtensionMethods
    {
        internal static HttpResponseType ToHttpResponseType(this int httpStatusCode)
        {
            if (httpStatusCode >= 100 && httpStatusCode < 200)
                return HttpResponseType.Informational;
            else if (httpStatusCode >= 200 && httpStatusCode < 300)
                return HttpResponseType.Success;
            else if (httpStatusCode >= 300 && httpStatusCode < 400)
                return HttpResponseType.Redirection;
            else if (httpStatusCode >= 400 && httpStatusCode < 500)
                return HttpResponseType.ClientError;
            else
                return HttpResponseType.ServerError;
        }

        internal static HttpResponseType ToHttpResponseType(this System.Net.HttpStatusCode statusCode)
        {
            return ToHttpResponseType((int)statusCode);
        }

        internal static string CleanContentType(this string contentTypeHeaderValue)
        {
            if (!contentTypeHeaderValue.Contains(";"))
                return contentTypeHeaderValue;

            string[] parts = contentTypeHeaderValue.Split(';');
            if (parts.Length > 0)
                return parts[0].Trim();
            else
                return null;
        }

        internal static async Task<T> ConvertToDataModel<T>(this Http.IHttpResponse response) where T : ODDataModel
        {
            using (Stream stream = await response.GetResponseStreamAsync())
            {
                var reader = new StreamReader(stream);
                string data = await reader.ReadToEndAsync();
                T result = data.ConvertToDataModel<T>();
                return result;
            }
        }

        internal static T ConvertToDataModel<T>(this string jsonString) where T : ODDataModel
        {
            try
            {
                T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
#if DEBUG
                result.OriginalJson = jsonString;
#endif
                return result;
            }
            catch (Exception ex)
            {
                throw new ODSerializationException(ex.Message, jsonString, ex);
            }
        }
    }

    public enum HttpResponseType
    {
        Informational,
        Success,
        Redirection,
        ClientError,
        ServerError
    }
}
