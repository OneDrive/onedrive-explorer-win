using System;
using System.IO;
using System.Threading.Tasks;

namespace OneDrive
{
    internal class LargeFileUploader
    {
        public ODConnection Connection { get; set; }
        public ODUploadSession UploadSession { get; set; }
        public Stream DataSource { get; set; }
        public ItemUploadOptions UploadOptions { get; set; }

        public LargeFileUploader(ODConnection connection, ODUploadSession uploadSession, Stream dataSource, ItemUploadOptions options)
        {
            Connection = connection;
            UploadSession = uploadSession;
            DataSource = dataSource;
            UploadOptions = options;
        }

        private void UpdateProgress(long bytesTrasnfered)
        {
            long totalBytes = DataSource.Length;

            var reporter = UploadOptions.ProgressReporter;
            if (null != reporter)
            {
                int percentComplete = (int)(((double)bytesTrasnfered / totalBytes) * 100.0);
                reporter(percentComplete, bytesTrasnfered, totalBytes);
            }
        }

        public async Task<ODItem> UploadFileStream()
        {
            long currentPosition = 0;

            ODItem uploadedItem = null;
            byte[] fragmentBuffer = new byte[UploadOptions.FragmentSize];
            while (currentPosition < DataSource.Length)
            {
                long endPosition = currentPosition + UploadOptions.FragmentSize;
                if (endPosition > DataSource.Length)
                {
                    endPosition = DataSource.Length;
                }
                await DataSource.ReadAsync(fragmentBuffer, 0, (int)Math.Max(0, endPosition - currentPosition));

                var response = await ExecuteUploadFragment(currentPosition, Math.Max(0, endPosition-1), fragmentBuffer);
                if (response is ODUploadSession)
                {
                    UploadSession.ApplySessionDelta((ODUploadSession)response);
                }
                else if (response is ODItem)
                {
                    uploadedItem = (ODItem)response;
                }
                UpdateProgress(endPosition);
                currentPosition = endPosition;
            }

            return uploadedItem;
        }

        /// <summary>
        /// Uploads a fragment to the UploadSession.UploadUrl end point. Returns either an ODUploadSession
        /// with the latest information about expected ranges, or an ODItem when the file is complete.
        /// </summary>
        /// <param name="startByte"></param>
        /// <param name="endByte"></param>
        /// <param name="fragment"></param>
        /// <returns></returns>
        private async Task<ODDataModel> ExecuteUploadFragment(long startByte, long endByte, byte[] fragment)
        {
            Uri serviceUri = new Uri(UploadSession.UploadUrl);
            if (endByte > DataSource.Length || startByte > DataSource.Length || endByte <= startByte)
            {
                throw new ArgumentException("range can't go past file length");
            }

            ODDataModel responseObject = await Connection.PutFileFragment(serviceUri, fragment, new ContentRange 
            {
                FirstByteIndex = startByte, 
                LastByteIndex = endByte,
                TotalLengthBytes = DataSource.Length 
            });

            return responseObject;
        }
    }
}
