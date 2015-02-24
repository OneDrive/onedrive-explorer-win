using System;
using System.Collections.Generic;

namespace OneDrive
{
    public class ItemRetrievalOptions : RetrievalOptions
    {
        public ThumbnailRetrievalOptions Thumbnails { get; set; }

        public ChildrenRetrievalOptions Children { get; set; }

        public static ItemRetrievalOptions Default
        {
            get { return new ItemRetrievalOptions(); }
        }

        public static ItemRetrievalOptions DefaultWithChildren
        {
            get { return new ItemRetrievalOptions { Children = ChildrenRetrievalOptions.Default }; }
        }

        public static ItemRetrievalOptions DefaultWithChildrenThumbnails
        {
            get { return new ItemRetrievalOptions { Children = ChildrenRetrievalOptions.DefaultWithThumbnails }; }
        }

        public override IEnumerable<ODataOption> ToOptions()
        {
            var options = new List<ODataOption>();

            if (null != Thumbnails)
                options.Add(new ExpandOData { PropertyToExpand = ApiConstants.ThumbnailsRelationshipName, AdditionalOptions = Thumbnails.ToOptions() });
            if (null != Children)
                options.Add(new ExpandOData { PropertyToExpand = ApiConstants.ChildrenRelationshipName, AdditionalOptions = Children.ToOptions() });
            return options;
        }
    }
}
