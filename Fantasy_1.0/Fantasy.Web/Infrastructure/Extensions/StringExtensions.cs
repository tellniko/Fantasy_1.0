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

        public static string ToFirstWord(this string str)
        {
            return Regex.Match(str, "^[A-Z]{1}[a-z]+(?=[A-Z])").ToString();
        }

        public static string ToNoFirstWord(this string str)
        {
            return str.Replace(Regex.Match(str, "^[A-Z]{1}[a-z]+(?=[A-Z])").ToString(), string.Empty);
        }

        public static string ToShortName(this string str)
        {
            var names = str.Split(' ').ToArray();

            if (names.Length > 2)
            {
                if (char.IsLower(names[names.Length - 2][0]))
                {
                    names[names.Length - 1] = names[names.Length - 2] + " " + names[names.Length - 1];
                }
            }

            if (names.Length == 1)
            {
                return names[names.Length - 1];

            }

            return names[0][0] + ". " + names[names.Length - 1];
        }

        public static string ToLastName(this string str)
        {
            var names = str.Split(' ').ToArray();

            if (names.Length > 2)
            {
                if (char.IsLower(names[names.Length - 2][0]))
                {
                    names[names.Length - 1] = names[names.Length - 2] + " " + names[names.Length - 1];
                }
            }

            if (names.Length == 1)
            {
                return names[names.Length - 1];
            }

            return names[names.Length - 1];
        }

        public static string ToFuckinNormalName(this string str)
        {
            return str.Replace("é", "e")
                .Replace("ú", "u")
                .Replace("ß", "b")
                .Replace("ü", "u")
                .Replace("ú", "u")
                .Replace("ö", "o")
                .Replace("Ç", "C")
                .Replace("Ø", "O")
                .Replace("ó", "o")
                .Replace("ä", "a")
                .Replace("á", "a")
                .Replace("ï", "i")
                .Replace("í", "i")
                .Replace("ø", "o");
        }
    }
}
