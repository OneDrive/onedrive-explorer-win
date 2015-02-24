using System;

namespace OneDrive
{
    public class ViewChangesOptions : RequestOptions
    {
        internal const string ViewChangesTokenKey = "token";
        
        public string StartingToken 
        {
            get { return ValueForQueryString(ViewChangesTokenKey); }
            set { SetValueForQueryString(ViewChangesTokenKey, value); }
        }

        public int? PageSize 
        {
            get { return ValueForQueryString(ApiConstants.PageSizeQueryParameterKey).ToNullableInt(); }
            set { SetValueForQueryString(ApiConstants.PageSizeQueryParameterKey, value.ToString()); }
        }

        public static ViewChangesOptions Default
        {
            get { return new ViewChangesOptions(); }
        }
    }
}
