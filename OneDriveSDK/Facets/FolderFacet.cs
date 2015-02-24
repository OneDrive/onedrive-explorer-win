using System;
using Newtonsoft.Json;

namespace OneDrive.Facets
{
    public class FolderFacet
    {
        [JsonProperty("childCount")]
        public long ChildCount { get; set; }
    }
}
