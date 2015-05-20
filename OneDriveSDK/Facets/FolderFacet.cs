using System;
using Newtonsoft.Json;

namespace OneDrive.Facets
{
    public class FolderFacet
    {
        [JsonProperty("childCount", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public long ChildCount { get; set; }
    }
}
