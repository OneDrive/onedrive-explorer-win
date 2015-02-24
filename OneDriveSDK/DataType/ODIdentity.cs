using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODIdentity : ODDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
