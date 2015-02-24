using System;

namespace OneDrive
{
    public class ItemUploadOptions : RequestOptions
    {
        private long _fragmentSize;

        public ItemUploadOptions()
        {
            NameConflict = NameConflictBehavior.Fail;
            FragmentSize = ApiConstants.UploadFragmentSizeBytes;
            AllowParallelUpload = false;
        }

        /// <summary>
        /// Specifies how name conflicts are controlled by the service.
        /// </summary>
        public NameConflictBehavior NameConflict 
        {
            get { return ValueForQueryString(ApiConstants.NameConflictParameter).FromEnumString<NameConflictBehavior>(); }
            set { SetValueForQueryString(ApiConstants.NameConflictParameter, value.ToEnumString()); }
        }

        /// <summary>
        /// Enables conditional upload based on etag value
        /// </summary>
        public string IfMatchETag
        {
            get { return ValueForHeader(ApiConstants.IfMatchHeaderName); }
            set { SetValueForHeader(ApiConstants.IfMatchHeaderName, value); }
        }

        /// <summary>
        /// For large files, enables parallel upload of fragments.
        /// </summary>
        public bool AllowParallelUpload { get; set; }

        /// <summary>
        /// Specifies the size of fragment to split the upload for resumable upload transfers.
        /// </summary>
        public long FragmentSize 
        {
            get { return _fragmentSize; }
            set
            {
                if (value % ApiConstants.FragmentByteAlignmentBytes != 0)
                {
                    throw new ArgumentException("Fragment size must be a multiple of 320kb.");
                }
                _fragmentSize = value;
            }
        }

        /// <summary>
        /// Allows your app to provide a delegate that is called as the file is uploaded to report progress.
        /// </summary>
        public ProgressReportDelegate ProgressReporter { get; set; }

        /// <summary>
        /// Returns an ItemUploadOptions instance with the default values.
        /// </summary>
        public static ItemUploadOptions Default
        {
            get{ return new ItemUploadOptions(); }
        }
    }
}
