using System;
using Newtonsoft.Json;

namespace OneDrive.Facets
{
    public class ImageFacet
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
