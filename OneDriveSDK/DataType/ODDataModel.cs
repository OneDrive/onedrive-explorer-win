using System;
using Newtonsoft.Json;

namespace OneDrive
{
    /// <summary>
    /// A common base class for all classes that are client/service communication related.
    /// </summary>
    public class ODDataModel
    {
#if DEBUG
        /// <summary>
        /// The origianl JSON data received from the service. This property is only available in debug builds.
        /// </summary>
        [JsonIgnore]
        public string OriginalJson { get; set; }
#endif
    }
}
