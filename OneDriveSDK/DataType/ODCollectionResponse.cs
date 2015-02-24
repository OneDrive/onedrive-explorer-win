using System;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODCollectionResponse<T> : ODDataModel
    {
        [JsonProperty("value")]
        public T[] Collection { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string NextLink { get; set; }

    }
}
