using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OneDrive
{
    public class ODAsyncTaskStatus : ODDataModel
    {
        [JsonProperty("operation"), JsonConverter(typeof(StringEnumConverter))]
        public AsyncJobType Operation { get; set; }

        [JsonProperty("percentageComplete")]
        public double PercentComplete { get; set; }

        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public AsyncJobStatus Status { get; set; }
        
    }

    public class ODAsyncTask
    {
        public ODAsyncTaskStatus Status { get; set; }

        public Uri StatusUri { get; set; }

        public Uri RequestUri { get; set; }

        public ODItem FinishedItem { get; set; }
    }


    public enum AsyncJobType
    {
        [EnumMember(Value="DownloadUrl")]
        DownloadUrl,
        [EnumMember(Value = "CopyItem")]
        CopyItem
    }

    public enum AsyncJobStatus
    {
        [EnumMember(Value = "NotStarted")]
        NotStarted,

        [EnumMember(Value = "InProgress")]
        InProgress,

        [EnumMember(Value = "Complete")]
        Complete
    }
}
