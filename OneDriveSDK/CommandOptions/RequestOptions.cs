using System;
using System.Collections.Generic;

namespace OneDrive
{
    public abstract class RequestOptions
    {
        protected RequestOptions()
        {
            HeadersToSet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            QueryStringParameters = new Dictionary<string, string>(StringComparer.Ordinal);
        }

        private Dictionary<string, string> HeadersToSet { get; set; }
        private Dictionary<string, string> QueryStringParameters { get; set; }

        protected string ValueForHeader(string headerName)
        {
            string value;
            HeadersToSet.TryGetValue(headerName, out value);
            return value;
        }

        protected void SetValueForHeader(string headerName, string value)
        {
            if (null == value)
                HeadersToSet.Remove(headerName);
            else
                HeadersToSet[headerName] = value;
        }

        protected string ValueForQueryString(string key)
        {
            string value;
            QueryStringParameters.TryGetValue(key, out value);
            return value;
        }

        protected void SetValueForQueryString(string key, string value)
        {
            if (null == value)
                QueryStringParameters.Remove(key);
            else
                QueryStringParameters[key] = value;
        }

        internal virtual void ModifyRequest(Http.IHttpRequest request)
        {
            foreach (var header in HeadersToSet)
            {
                request.Headers[header.Key] = header.Value;
            }
        }

        internal virtual void ModifyQueryString(QueryStringBuilder qsb)
        {
            foreach (var query in QueryStringParameters)
            {
                qsb.Add(query.Key, query.Value);
            }
        }
    }
}
