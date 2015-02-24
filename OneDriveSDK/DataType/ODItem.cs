using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace OneDrive
{
    public class ODItem : ODDataModel
    {
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("etag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ETag { get; set; }

        [JsonProperty("ctag", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CTag { get; set; }

        [JsonProperty("createdBy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ODIdentitySet CreatedBy { get; set; }

        [JsonProperty("createdDateTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTimeOffset CreatedDateTime { get; set; }

        [JsonProperty("lastModifiedBy", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ODIdentitySet LastModifiedBy { get; set; }

        [JsonProperty("lastModifiedDateTime", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        [JsonProperty("size", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public long Size { get; set; }

        [JsonProperty("webUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string WebUrl { get; set; }

        [JsonProperty("parentReference", NullValueHandling = NullValueHandling.Ignore)]
        public ODItemReference ParentReference { get; set; }

        [JsonProperty("folder", NullValueHandling=NullValueHandling.Ignore)]
        public Facets.FolderFacet Folder { get; set; }

        [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.FileFacet File { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.ImageFacet Image { get; set; }

        [JsonProperty("photo", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.PhotoFacet Photo { get; set; }

        [JsonProperty("audio", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.AudioFacet Audio { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.VideoFacet Video { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.LocationFacet Location { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.TombstoneFacet Deleted { get; set; }

        [JsonProperty("specialFolder", NullValueHandling = NullValueHandling.Ignore)]
        public Facets.SpecialFolderFacet SpecialFolder { get; set; }

        [JsonProperty(ApiConstants.NameConflictParameter, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public NameConflictBehavior? NameConflictBehaiorAnnotation { get; set; }

        [JsonProperty("@content.downloadUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DownloadUrlAnnotation { get; set; }

        [JsonProperty("@content.sourceUrl", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SourceUrlAnnotation { get; set; }

        [JsonProperty("children@odata.nextLink", DefaultValueHandling=DefaultValueHandling.Ignore)]
        public string ChildrenNextLinkAnnotation { get; set; }

        [JsonProperty(ApiConstants.ThumbnailsRelationshipName, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ODThumbnailSet[] Thumbnails { get; set; }

        [JsonProperty(ApiConstants.ChildrenRelationshipName, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ODItem[] Children { get; set; }
    }

    public enum NameConflictBehavior
    {
        [EnumMember(Value = "fail")]
        Fail,

        [EnumMember(Value = "replace")]
        Replace,

        [EnumMember(Value = "rename")]
        Rename
    }
}
