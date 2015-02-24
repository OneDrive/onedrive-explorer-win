using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OneDrive.Facets
{
    public class SpecialFolderFacet
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public enum KnownFolder
    {
        [EnumMember(Value = "approot")]
        AppFolder,

        [EnumMember(Value = "documents")]
        Documents,

        [EnumMember(Value = "photos")]
        Photos,

        [EnumMember(Value = "cameraroll")]
        CameraRoll,

        [EnumMember(Value = "public")]
        Public
    }
}
