using System;
using System.Collections.Generic;

namespace OneDrive
{
    public class ChildrenRetrievalOptions : RetrievalOptions
    {
        public ThumbnailRetrievalOptions ExpandThumbnails { get; set; }

        public string[] SelectProperties { get; set; }

        public int? PageSize { get; set; }

        /// <summary>
        /// Retrieve children using the default parameters and page size.
        /// </summary>
        public static ChildrenRetrievalOptions Default
        {
            get { return new ChildrenRetrievalOptions(); }
        }

        /// <summary>
        /// Retrieve children with the default values + thumbnails expanded
        /// </summary>
        public static ChildrenRetrievalOptions DefaultWithThumbnails
        {
            get { return new ChildrenRetrievalOptions { ExpandThumbnails = ThumbnailRetrievalOptions.Default }; }
        }

        public override IEnumerable<ODataOption> ToOptions()
        {
            List<ODataOption> options = new List<ODataOption>();

            if (ExpandThumbnails != null)
            {
                options.Add(new ExpandOData { PropertyToExpand = ApiConstants.ThumbnailsRelationshipName, AdditionalOptions = ExpandThumbnails.ToOptions() });
            }

            if (null != SelectProperties && SelectProperties.Length > 0)
            {
                options.Add(new SelectOData { FieldNames = SelectProperties });
            }

            if (null != PageSize)
            {
                options.Add(new TopOData { PageSize = PageSize.Value });
            }

            return options;
        }
    }
}
