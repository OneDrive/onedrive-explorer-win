using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODPermission : ODDataModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("roles")]
        public string[] Roles { get; set; }

        [JsonProperty("link")]
        public Facets.SharingLinkFacet Link { get; set; }

        [JsonProperty("inheritedFrom")]
        public ODItemReference InheritedFrom { get; set; }
    }
}
