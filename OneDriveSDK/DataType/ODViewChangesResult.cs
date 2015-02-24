using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODViewChangesResult : ODItemCollection
    {
        [JsonProperty("@changes.hasMoreChanges")]
        public bool HasMoreChanges { get; set; }

        [JsonProperty("@changes.token")]
        public string NextToken { get; set; }

        [JsonProperty("@changes.resync", DefaultValueHandling=DefaultValueHandling.IgnoreAndPopulate)]
        public ResyncLogic ResyncBehavior { get; set; }
    }

    public enum ResyncLogic
    {
        [EnumMember(Value = "none")]
        NoResyncRequired = 0,

        [EnumMember(Value = "ResetCacheAndFullSync")]
        ResetCacheAndFullSync,

        [EnumMember(Value = "FullSyncAndUploadDifferences")]
        FullSyncAndUploadDifferences
    }
}
