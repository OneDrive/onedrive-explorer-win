using System;
using System.Threading.Tasks;

namespace OneDrive
{
    public static class ItemExtensionMethods
    {
        /// <summary>
        /// Returns true if the item is capible of having children items.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool CanHaveChildren(this ODItem item)
        {
            return item.Folder != null;
        }

        /// <summary>
        /// Returns an item reference instance for the item, based on the item's ID and item's parent's drive ID.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ODItemReference ItemReference(this ODItem item)
        {
            if (item.ParentReference == null)
                return ODConnection.ItemReferenceForItemId(item.Id);
            else
                return ODConnection.ItemReferenceForItemId(item.Id, item.ParentReference.DriveId);
        }

        /// <summary>
        /// Returns a paged children collection for the item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="connection"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static async Task<ODItemCollection> PagedChildrenCollectionAsync(this ODItem item, ODConnection connection, ChildrenRetrievalOptions options)
        {
            if (item.Children == null)
            {
                var firstPage = await connection.GetChildrenOfItemAsync(item.ItemReference(), options);
                item.Children = firstPage.Collection;
                item.ChildrenNextLinkAnnotation = firstPage.NextLink;
            }

            return new ODItemCollection { Collection = item.Children, NextLink = item.ChildrenNextLinkAnnotation };
        }

        /// <summary>
        /// Returns the default thumbnail for a particular size
        /// </summary>
        /// <param name="item"></param>
        /// <param name="connnection"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static async Task<ODThumbnail> GetDefaultThumbnailUrlAsync(this ODItem item, ODConnection connnection, string size)
        {
            if (item.Thumbnails == null)
            {
                // Item wasn't loaded with thumbnails, so do that now
                item.Thumbnails = await connnection.GetThumbnailsForItemAsync(item.ItemReference(), ThumbnailRetrievalOptions.Default);
            }

            if (null != item.Thumbnails && item.Thumbnails.Length > 0)
            {
                return item.Thumbnails[0].ThumbnailForSize(size);
            }

            return null;
        }

        /// <summary>
        /// Converts an ODItem into a Json String
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string JsonString(this ODDataModel item)
        {
            object jsonSource = item;
#if DEBUG
            // Pretty-print the JSON by round tripping through the JSON converter
            if (null != item.OriginalJson)
            {
                jsonSource = Newtonsoft.Json.JsonConvert.DeserializeObject(item.OriginalJson);
            }
#endif
            return Newtonsoft.Json.JsonConvert.SerializeObject(jsonSource, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns the Path for an item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string Path(this ODItem item, bool includeApiRoot = false)
        {
            if (null != item.ParentReference)
            {
                if (!includeApiRoot)
                {
                    string userPath = item.ParentReference.Path.Split(new char[] { ':' })[1];
                    if (null != userPath && !userPath.EndsWith("/"))
                        userPath = string.Concat(userPath, "/");
                    return "/" + userPath + item.Name;
                }

                var parentPath = item.ParentReference.Path;
                if (null != parentPath && !parentPath.EndsWith("/"))
                {
                    parentPath = string.Concat(parentPath, "/");
                }

                return parentPath + item.Name;
            }

            return null;
        }
    
        /// <summary>
        /// Returns a stream for the contents of an item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static async Task<System.IO.Stream> GetContentStreamAsync(this ODItem item, ODConnection connection, StreamDownloadOptions downloadOptions)
        {
            return await connection.DownloadStreamForItemAsync(item.ItemReference(), downloadOptions);
        }
    }
}
