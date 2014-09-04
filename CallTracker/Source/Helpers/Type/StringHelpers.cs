using System;
using System.Text.RegularExpressions;

namespace CallTracker.Helpers
{
    public static class StringHelpers
    {
        public static string SeperateCamelCase(string input)
        {
            var r = new Regex(@"(?!^)(?=[A-Z])");
            return r.Replace(input, " ");
        }

        public static string JoinCamelCase(string input)
        {
            return input.Replace(" ", "");
        }

        public static string RemoveColons(string input)
        {
            return input.Replace(":", "");
        }
    }

    public static class StringExtensions
    {
        public static string ToBold(this string s)
        {
            return String.Format("\b {0}\b0 ", s);
        }

        public static string ToRtf(this string s)
        {
            return @"{\rtf1\ansi" + s + "}";
        }

        /// <summary>
        /// Returns True if string is only numbers and contains '.', '-', ' '. Returns false if no numbers.
        /// </summary>
        public static bool IsDigits(this string s)
        {
            var len = s.Length;
            var numberIndex = 0;
            for (var i = 0; i < len; ++i)
            {
                var c = s[i];
                if (c >= '0' && c <= '9')
                {
                    numberIndex = i + 1;
                    break;
                }

                if (c != '.' && c != '-' && c != ' ')
                    return false;
            }
            if (numberIndex == 0) return false;
            
            for (var i = numberIndex; i < len; ++i)
            {
                var c = s[i];
                if (!(c >= '0' && c <= '9') && c != '.' && c != '-' && c != ' ')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Returns True if string is only letters and contains '.', '-', ' '. Returns false if no letters.
        /// </summary>
        public static bool IsLetters(this string s)
        {
            var len = s.Length;
            var letterIndex = -1;
            for (var i = 0; i < len; ++i)
            {
                var c = s[i];
                if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    letterIndex = i + 1;
                    break;
                }

                if (c != '.' && c != '-' && c != ' ')
                    return false;
            }
            if (letterIndex == 0) return false;
            for (var i = letterIndex; i < len; ++i)
            {
                var c = s[i];
                if (!(c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') && c != '.' && c != '-' && c != ' ')
                    return false;
            }
            return true;
        }
    }
}