using System;

namespace OneDrive
{
    public class ItemDeleteOptions : RequestOptions
    {
        public string IfMatchETag
        {
            get { return ValueForHeader(ApiConstants.IfMatchHeaderName); }
            set { SetValueForHeader(ApiConstants.IfMatchHeaderName, value); }
        }

        public static ItemDeleteOptions Default
        {
            get
            {
                return new ItemDeleteOptions();
            }
        }
    }
}
