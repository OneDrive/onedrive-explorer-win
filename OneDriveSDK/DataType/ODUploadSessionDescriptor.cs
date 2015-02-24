using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OneDrive
{
    internal class ODUploadSessionDescriptor
    {
        [JsonProperty(ApiConstants.NameConflictParameter, DefaultValueHandling = DefaultValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public NameConflictBehavior FilenameConflictBehavior { get; set; }

        [JsonProperty("name", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public string Filename { get; set; }
    }
}
