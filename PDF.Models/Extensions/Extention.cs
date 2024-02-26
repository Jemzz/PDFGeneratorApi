using System.Text.RegularExpressions;

namespace PDF.Models.Extensions
{
    public static class Extention
    {
        public static string ToReadableName(this string value)
        {
            return Regex.Replace(value, "(?!^)([A-Z])", " $1");
        }
    }
}
