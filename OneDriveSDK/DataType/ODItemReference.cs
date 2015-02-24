using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODItemReference : ODDataModel
    {
        [JsonProperty("driveId")]
        public string DriveId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
