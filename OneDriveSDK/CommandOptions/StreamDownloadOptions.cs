using System;

namespace OneDrive
{
    public class StreamDownloadOptions : RequestOptions
    {
        public ContentRange ContentRange 
        {
            get
            {
                return ContentRange.FromContentRangeHeaderValue(ValueForHeader(ApiConstants.RangeHeaderName));
            }

            set
            {
                SetValueForHeader(ApiConstants.RangeHeaderName, 
                    value != null ? value.ToContentRangeHeaderValue() : null);
            }
        }

        public string IfMatchETag
        {
            get { return ValueForHeader(ApiConstants.IfMatchHeaderName); }
            set { SetValueForHeader(ApiConstants.IfMatchHeaderName, value); }
        }

        public static StreamDownloadOptions Default
        {
            get { return new StreamDownloadOptions(); }
        }
    }
}
