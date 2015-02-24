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
                thumbnailSelect = new SelectOData { FieldNames = SelectThumbnailNames };

            options.Add(new ExpandOData
            {
                PropertyToExpand = ApiConstants.ThumbnailsRelationshipName,
                Select = thumbnailSelect
            });

            return EmptyCollection;
        }
    }
}
