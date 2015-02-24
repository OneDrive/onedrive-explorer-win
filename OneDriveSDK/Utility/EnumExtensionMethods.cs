using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace OneDrive
{
    internal static class EnumExtensionMethods
    {
        public static string ToEnumString<T>(this T type)
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var field = enumType.GetRuntimeField(name);
            var attribute = field.GetCustomAttribute<EnumMemberAttribute>(true);
            return attribute.Value;
        }

        public static T FromEnumString<T>(this string value, bool ignoreCase = false)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = enumType.GetRuntimeField(name).GetCustomAttribute<EnumMemberAttribute>(true);
                if (enumMemberAttribute.Value.Equals(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                    return (T)Enum.Parse(enumType, name);
            }
            return default(T);
        }

        public static int? ToNullableInt(this string value)
        {
            if (value == null)
                return null;

            int parseValue;
            if (int.TryParse(value, out parseValue))
                return parseValue;

            return null;
        }
    }
}
