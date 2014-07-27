using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CallTracker.Helpers
{
    public static class StringHelpers
    {
        public static string SeperateCamelCase(string _input)
        {
            Regex r = new Regex(@"(?!^)(?=[A-Z])");
            return r.Replace(_input, " ");
        }

        public static string JoinCamelCase(string _input)
        {
            return _input.Replace(" ", "");
        }
    }
}
