using System;
using System.IO;
using System.Threading.Tasks;

namespace OneDrive
{

    public delegate void ProgressReportDelegate(int percentComplete, long bytesTransfered, long bytesTotal);

    public static class StreamExtensions
    {
        public static async Task<long> CopyWithProgressAsync(this Stream source, Stream destination,
            ProgressReportDelegate progressReport = null, long sourceLength = 0, int bufferSize = 64 * 1024)
        {
            long bytesWritten = 0;
            long totalBytesToWrite = sourceLength;

            byte[] copy_buffer = new byte[bufferSize];
            int read;
            while ((read = await source.ReadAsync(copy_buffer, 0, copy_buffer.Length)) > 0)
            {
                await destination.WriteAsync(copy_buffer, 0, read);
                bytesWritten += read;

                System.Diagnostics.Debug.WriteLine("CopyWithProgress: {0} / {1}", bytesWritten, totalBytesToWrite);
                if (null != progressReport)
                {
                    int percentComplete = 0;
                    if (sourceLength > 0)
                        percentComplete = (int)((bytesWritten/(double)totalBytesToWrite) * 100);    
                    progressReport(percentComplete, bytesWritten, totalBytesToWrite);
                }
            }

            await destination.FlushAsync();

            return bytesWritten;
        }

        public static bool TryGetLength(this Stream source, out long length)
        {
            if (source == null)
            {
                length = -1;
                return false;
            }

            try
            {
                length = source.Length;
                return true;
            }
            catch
            {
                length = -1;
                return false;
            }
        }
    }
}
