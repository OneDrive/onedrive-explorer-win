using System;

namespace OneDrive
{
    public static class ThumbnailExtensionMethods
    {
        public static ODThumbnail ThumbnailForSize(this ODThumbnailSet thumbnail, string size)
        {
            if (size.Equals("small", StringComparison.OrdinalIgnoreCase))
                return thumbnail.Small;
            else if (size.Equals("medium", StringComparison.OrdinalIgnoreCase))
                return thumbnail.Medium;
            else if (size.Equals("large", StringComparison.OrdinalIgnoreCase))
                return thumbnail.Large;

            return null;
        }
    }
}
