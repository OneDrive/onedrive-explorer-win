using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDrive
{
    internal static class ApiConstants
    {
        // Define OData constants
        public const string ExpandQueryParameterKey = "expand";
        public const string SearchQueryParameterKey = "q";
        public const string PageSizeQueryParameterKey = "top";
        public const string SelectQueryParameterKey = "select";

        // OneDrive reserved ids
        public const string RootFolderItemId = "root";

        // OneDrive service actions
        public const string ViewChangesServiceAction = "view.changes";
        public const string SearchServiceAction = "view.search";
        public const string CopyItemAction = "action.copy";
        public const string CreateLinkAction = "action.createLink";
        public const string UploadCreateSessionAction = "upload.createSession";

        public const string PathComponentSeparator = "/";

        public const string ContentTypeJson = "application/json";
        public const string ContentTypeBinary = "application/octet-stream";

        public const string HttpPost = "POST";
        public const string HttpPut = "PUT";
        public const string HttpGet = "GET";
        public const string HttpDelete = "DELETE";
        public const string HttpPatch = "PATCH";

        public const string IfMatchHeaderName = "If-Match";
        public const string RangeHeaderName = "Range";
        public const string ContentRangeHeaderName = "Content-Range";
        public const string LocationHeaderName = "Location";

        public const string NameConflictParameter = "@name.conflictBehavior";

        public const string ChildrenRelationshipName = "children";
        public const string ThumbnailsRelationshipName = "thumbnails";
        public const string ContentRelationshipName = "content";

        public const string PreferHeaderName = "Prefer";
        public const string PreferAsyncResponseValue = "respond-async";

        // 320kb is the LCM for 80kb and 64kb which are the optimal fragment alignment sizes. 320kb x 12 = ~4MB per fragment.
        public const long FragmentByteAlignmentBytes = 320 * 1024;
        public const long UploadFragmentSizeBytes = 12 * FragmentByteAlignmentBytes;
    }
}
