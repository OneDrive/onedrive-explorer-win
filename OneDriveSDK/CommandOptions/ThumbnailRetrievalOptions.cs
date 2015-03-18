using System;
using System.Collections.Generic;

namespace OneDrive
{
    public class ThumbnailRetrievalOptions : RetrievalOptions
    {

        /// <summary>
        /// List of thumbnail size names to return
        /// </summary>
        public string[] SelectThumbnailNames { get; set; }

        /// <summary>
        /// Retrieve the default thumbnails for an item
        /// </summary>
        public static ThumbnailRetrievalOptions Default { get { return new ThumbnailRetrievalOptions(); } }

        /// <summary>
        /// Returns a string like "select=small,medium" that can be used in an expand parameter value
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ODataOption> ToOptions()
        {
            List<ODataOption> options = new List<ODataOption>();

            SelectOData thumbnailSelect = null;
            if (SelectThumbnailNames != null && SelectThumbnailNames.Length > 0)
            {
                thumbnailSelect = new SelectOData { FieldNames = SelectThumbnailNames };
                options.Add(thumbnailSelect);
            }
            
            return options;
        }
    }

    public static class ThumbnailSize
    {
        public const string Small = "small";
        public const string Medium = "medium";
        public const string Large = "large";
        public const string SmallSquare = "smallSquare";
        public const string MediumSquare = "mediumSquare";
        public const string LargeSquare = "largeSquare";

        public static string CustomSize(int width, int height, bool cropped)
        {
            return string.Format("c{0}x{1}{2}", width, height, cropped ? "_Crop" : "");
        }

    }
}
