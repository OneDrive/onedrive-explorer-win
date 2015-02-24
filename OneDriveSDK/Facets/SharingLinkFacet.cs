using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OneDrive.Facets
{
    public class SharingLinkFacet
    {
        [JsonProperty("webUrl")]
        public string WebUrl { get; set; }

        [JsonProperty("application")]
        public ODIdentity Application { get; set; }

        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public LinkType Type { get; set; }
    }

    public enum LinkType
    {
        [EnumMember(Value = "view")]
        View,

        [EnumMember(Value = "edit")]
        Edit
    }
}
