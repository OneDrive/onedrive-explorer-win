using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OneDrive
{
    public class ODDrive : ODDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("driveType"), JsonConverter(typeof(StringEnumConverter))]
        public DriveType DriveType { get; set; }

        [JsonProperty("owner")]
        public ODIdentitySet Owner { get; set; }

        [JsonProperty("quota")]
        public Facets.QuotaFacet Quota { get; set; }
    }

    public enum DriveType
    {
        [EnumMember(Value = "personal")]
        Personal,

        [EnumMember(Value = "business")]
        Business
    }
}
