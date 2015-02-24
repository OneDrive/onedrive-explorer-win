using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODThumbnailSet : ODDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("small", NullValueHandling=NullValueHandling.Ignore)]
        public ODThumbnail Small { get; set; }

        [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)]
        public ODThumbnail Medium { get; set; }

        [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
        public ODThumbnail Large { get; set; }
    }
}
