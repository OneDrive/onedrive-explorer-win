using System;
using System.Threading.Tasks;

namespace OneDrive
{
    internal static class ExceptionExtensions
    {
        public static async Task<ODServerException> ToException(this Http.IHttpResponse response)
        {
            var responseErrorType = response.StatusCode.ToHttpResponseType();
            if (responseErrorType != HttpResponseType.ServerError && responseErrorType != HttpResponseType.ClientError)
                throw new InvalidOperationException("Attempting to create exception for a non-error response");
            
            var contentType = response.ContentType.CleanContentType();
            if (null != contentType && contentType.Equals(ApiConstants.ContentTypeJson))
            {
                // Parse the error response json
                ODError errorObj = await response.ConvertToDataModel<ODError>();

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new ODAuthenticationException(null != errorObj ? errorObj.Message : response.StatusDescription)
                    {
                        HttpStatusCode = (int)response.StatusCode,
                        HttpStatusMessage = response.StatusDescription,
                        ServiceError = errorObj
                    };
                }
                else
                {
                    return new ODServerException(null != errorObj ? errorObj.Message : response.StatusDescription)
                    {
                        HttpStatusCode = (int)response.StatusCode,
                        HttpStatusMessage = response.StatusDescription,
                        ServiceError = errorObj
                    };
                }
            }
            else
            {
                return new ODServerException("HTTP response did not include a JSON error object", null);
            }
        }
    }
}
