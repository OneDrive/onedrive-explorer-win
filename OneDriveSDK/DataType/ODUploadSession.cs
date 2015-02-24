using System;
using Newtonsoft.Json;

namespace OneDrive
{
    internal class ODUploadSession : ODDataModel
    {
        [JsonProperty("uploadUrl")]
        public string UploadUrl { get; set; }

        [JsonProperty("expirationDateTime")]
        public DateTimeOffset Expiration { get; set; }

        [JsonProperty("nextExpectedRanges")]
        public string[] ExpectedRanges { get; set; }
    }
}
