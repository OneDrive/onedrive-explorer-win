using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OneDrive.Facets
{
    public class QuotaFacet
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("used")]
        public long Used { get; set; }

        [JsonProperty("remaining")]
        public long Remaining { get; set; }

        [JsonProperty("deleted")]
        public long Deleted { get; set; }

        [JsonProperty("state"), JsonConverter(typeof(StringEnumConverter))]
        public QuotaState State { get; set; }
    }

    public enum QuotaState
    {
        [EnumMember(Value = "normal")]
        Normal,

        [EnumMember(Value = "nearing")]
        Nearing,

        [EnumMember(Value = "critical")]
        Critical,

        [EnumMember(Value = "exceeded")]
        Exceeded
    }
}
