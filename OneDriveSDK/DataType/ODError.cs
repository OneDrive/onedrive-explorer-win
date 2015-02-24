using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODError : ODErrorDetail
    {
        [JsonProperty("error")]
        public ODErrorDetail Error { get; set; }
    }

    public class ODErrorDetail : ODDataModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("innererror")]
        public ODErrorDetail InnerError { get; set; }
    }
}
