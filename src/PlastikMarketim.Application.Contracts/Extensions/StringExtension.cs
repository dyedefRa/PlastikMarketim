using System.Linq;

namespace PlastikMarketim.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// wwwroot alanını kaldırır.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToFileShownPath(this string value)
        {
            return value.Replace("wwwroot", "");
        }

        public static bool IsValidTcNumber(this string value)
        {
            return value.Length == 11 && value.All(char.IsDigit);
        }

        internal static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        public static string FullPathToFilePath(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var splitted = value.Split('/');
            var path = "";
            for (int i = 1; i < splitted.Length; i++)
            {
                path = path + "/" + splitted[i];
            }
            return path;
        }

    }
}
