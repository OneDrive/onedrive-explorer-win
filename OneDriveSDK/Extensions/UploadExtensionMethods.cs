using System;

namespace OneDrive
{
    internal static class UploadExtensionMethods
    {
        public static void ApplySessionDelta(this ODUploadSession original, ODUploadSession latest)
        {
            if (latest.ExpectedRanges != null)
                original.ExpectedRanges = latest.ExpectedRanges;
            if (latest.Expiration > DateTimeOffset.MinValue)
                original.Expiration = latest.Expiration;
            if (latest.UploadUrl != null)
                original.UploadUrl = latest.UploadUrl;
        }
    }
}
