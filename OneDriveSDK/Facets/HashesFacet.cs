using System;
using Newtonsoft.Json;

namespace OneDrive.Facets
{
    public class HashesFacet
    {
        [JsonProperty("sha1Hash")]
        public string Sha1 { get; set; }

        [JsonProperty("crc32Hash")]
        public string Crc32 { get; set; }
    }
}
