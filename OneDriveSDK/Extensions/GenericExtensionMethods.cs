using System;
using Newtonsoft.Json;
using System.Net;

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

        public static T Copy<T>(this T sourceItem) where T : ODDataModel
        {
            string serialized = JsonConvert.SerializeObject(sourceItem);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static bool IsSuccess(this HttpStatusCode code)
        {
            int statusCode = (int)code;
            if (statusCode >= 200 && statusCode < 300)
                return true;
            else
                return false;
        }
    }
}
