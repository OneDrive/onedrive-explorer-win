using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODIdentitySet : ODDataModel
    {
        [JsonProperty("user", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public ODIdentity User { get; set; }

        [JsonProperty("device", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ODIdentity Device { get; set; }

        [JsonProperty("application", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ODIdentity Application { get; set; }
    }
}
