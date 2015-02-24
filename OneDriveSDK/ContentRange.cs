using System;

namespace OneDrive
{
    public class ContentRange
    {
        public long FirstByteIndex { get; set; }
        public long LastByteIndex { get; set; }
        public long TotalLengthBytes { get; set; }

        public long BytesInRange { get { return LastByteIndex - FirstByteIndex + 1; } }

        internal string ToContentRangeHeaderValue()
        {
            if (TotalLengthBytes > 0)
            {
                return string.Format("bytes {0}-{1}/{2}", FirstByteIndex, LastByteIndex, TotalLengthBytes);
            }
            else
            {
                return string.Format("bytes {0}-{1}", FirstByteIndex, LastByteIndex);
            }
        }

        internal static ContentRange FromContentRangeHeaderValue(string value)
        {
            ContentRange range = new ContentRange();
            const string valuePrefix = "bytes ";
            if (!value.StartsWith(valuePrefix, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Expected value to begin with 'bytes '", "value");

            string byteRange = value.Substring(valuePrefix.Length);
            long totalFileSize = 0, firstByte = 0, lastByte = 0;

            int indexOfSlash = byteRange.IndexOf('/');
            if (indexOfSlash > 0)
            {
                var totalFileSizeString = byteRange.Substring(indexOfSlash + 1);
                if (!Int64.TryParse(totalFileSizeString, out totalFileSize))
                    throw new ArgumentException("Couldn't parse the total file size from the value.");
                byteRange = byteRange.Substring(0, indexOfSlash);
            }

            int indexOfDash = byteRange.IndexOf('-');
            if (indexOfDash > 0)
            {
                var lastByteString = byteRange.Substring(indexOfDash + 1);
                var firstByteString = byteRange.Substring(0, indexOfDash);

                if (!Int64.TryParse(lastByteString, out lastByte) ||
                     !Int64.TryParse(firstByteString, out firstByte))
                {
                    throw new ArgumentException("Couldn't parse the first/last byte ranges from the value.");
                }
            }

            range.TotalLengthBytes = totalFileSize;
            range.FirstByteIndex = firstByte;
            range.LastByteIndex = lastByte;

            return range;
        }
    }
}
