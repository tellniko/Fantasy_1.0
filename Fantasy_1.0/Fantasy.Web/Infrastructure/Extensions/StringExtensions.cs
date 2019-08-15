using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fantasy.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ToPrice(this decimal value)
        {
            return "$" + value.ToString("F2");
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + m.Value[1]);
        }
    }
}
