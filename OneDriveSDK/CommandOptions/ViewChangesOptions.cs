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

        /// <summary>
        /// Select properties on the expanded objects
        /// </summary>
        public string Select 
        {
            get { return ValueForQueryString(ApiConstants.SelectQueryParameterKey); }
            set { SetValueForQueryString(ApiConstants.SelectQueryParameterKey, value); }
        }

        public static ViewChangesOptions Default
        {
            get { return new ViewChangesOptions(); }
        }
    }
}
