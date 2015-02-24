using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODThumbnail : ODDataModel
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
