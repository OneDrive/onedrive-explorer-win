using System;

namespace OneDrive
{
    internal static class GenericExtensionMethods
    {
        public static int OccurrencesOfCharacter(this string input, char lookFor)
        {
            int count = 0;
            foreach (char c in input)
                if (c == lookFor) count++;
            return count;
        }

        public static bool ValidFilename(this string filename)
        {
            char[] restrictedCharacters = { '\\', '/', ':', '*', '?', '<', '>', '|' };

            if (filename.IndexOfAny(restrictedCharacters) != -1)
            {
                return false;
            }

            return true;
        }
    }
}
