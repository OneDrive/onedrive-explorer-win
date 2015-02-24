using System;
using Newtonsoft.Json;

namespace OneDrive.Facets
{
    public class FileFacet
    {
        [JsonProperty("hashes", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public HashesFacet Hashes { get; set; }

        [JsonProperty("mimeType", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public string MimeType { get; set; }
    }
}
