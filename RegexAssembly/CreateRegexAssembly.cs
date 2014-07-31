using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RegexAssembly
{
    public class CreateRegexAssembly
    {
        private static readonly AssemblyName ASSEMBLYNAME = new AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");
        private static readonly string NAMESUFFIX = "Pattern";
        private static readonly string NAMESPACE = "Utilities.RegularExpressions";

        public static void Main()
        {
            List<MyRegex> RegexList = new List<MyRegex>
            {
                new MyRegex("Alpha",    @"^[a-z\-\s]+$", RegexOptions.IgnoreCase),
                new MyRegex("AlphaNum", @"^[a-z0-9\-\s]+$", RegexOptions.IgnoreCase),
                new MyRegex("Digit",    @"^[0-9\-\s]+$"),
                new MyRegex("UsernameLower", @"^[a-z]+[a-z0-9._]*[a-z0-9]+(?:@optusnet.com.au)?$"),
                new MyRegex("UsernameUpper", @"^[A-Z]+[A-Z0-9._]*[A-Z0-9]+(?:@optusnet.com.au)?$"),
                new MyRegex("BRAS",     @"^[a-z]{3}\d{3}\.[a-z]{2}$"),
                new MyRegex("CommonNBN",@"^([AVCSNIG]{3})" +                // Data Type
                                        @"(\d{12})$"),                      // Id
                new MyRegex("Mobile",   @"^(0|61)"+                         // Prefix
                                        @"(4\d{8})$"),                      // Number
                new MyRegex("DN",       @"^(0|61)" +                        // Prefix
                                        @"([2378]\d{8})$"),                 // Number
                new MyRegex("Node",     @"^(\d{2})([a-z]{2})_?(\d{3})$", RegexOptions.IgnoreCase),
                new MyRegex("CMBS",     @"\b(3[1-3])" +                      // State
                                        @"-?" +                             // Divider
                                        @"(\d{6})" +                        // Account
                                        @"(?:-|0|\s)?"+                     // Divider
                                        @"(\d)$"),                          // Flip
                new MyRegex("ICON",     @"^((?:1|5|8|9)\d{7})(\d{6})$"),
                new MyRegex("Name",     @"(?:(Mr|Mrs|miss|dr)\.?)?\s?" +             // Title (Followed by a ".")
                                        @"([a-z]+)" +                       // First Name
                                        @"\s([a-z]+(?:(?:-)[a-z]+)?)"              // Surnames
                                        , RegexOptions.IgnoreCase),
                new MyRegex("Address",  @"(?:(Unit|Lot|Level|Floor)\s)?" +  // Property Type
                                        @"(?:(\d+)(?:/|\\|\s)?)?" +         // Unit Number
                                        @"(\d+)" +                          // Property Number
                                        @"\s([a-z]+)" +                     // Street Name
                                        @"\s([a-z]+)\.?" +                  // Street Type
                                        @"\s([a-z]+)" +                     // Suburb
                                        @"(?:[,\s]+?([a-z]+))?" +           // State (Optional)
                                        @"(?:[,\s]+?(\d{4}))?"              // Postcode (Optional)
                                        , RegexOptions.IgnoreCase),
                new MyRegex("Address2", @"(?:(Unit|Lot|Level|Floor|P.?O.? Box)\s)?" +  // Property Type
                                        @"(?:(\d+)(?:/|\\|\s))?" +         // Unit Number
                                        @"(\d+)" +                          // Property Number
                                        @"\s([a-z]+(?:(?:\s|-)[a-z]+)?)" +                     // Street Name
                                        @"\s(st|rd|ave|hwy|cct|ct|cl|gr|street|road|avenue|highway|circuit|court|close|grove)\.?" +                  // Street Type
                                        @"\s([a-z]+(?:(?:\s|-)[a-z]+)?)" +                     // Suburb
                                        @"\s?(Victoria|Tasmania|Queensland|New South Wales|(?:South|Western) Australia|(?:Northern|Australian Captial) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)?" +           // State (Optional)
                                        @"\s?(\d{4})?"                      // Postcode (Optional)
                                        , RegexOptions.IgnoreCase),
                new MyRegex("ITCase",   @"\b(1[4-6])" +                           // Year
                                        @"(0\d|1[0-2])" +                       // Month
                                        @"(0\d|[1-3]\d|3[0-1])" +               // Date
                                        @"(\d{4})$")                             // 4 Digit id
            };

            Regex.CompileToAssembly(CreateCompilationInfo(RegexList), ASSEMBLYNAME);
        }

        private static RegexCompilationInfo[] CreateCompilationInfo(List<MyRegex> regexList)
        {
            RegexCompilationInfo[] regexes = new RegexCompilationInfo[regexList.Count];

            for (int i = 0; i < regexList.Count; i++)
                regexes[i] = new RegexCompilationInfo(regexList[i].Pattern,
                                                      regexList[i].Options,
                                                      regexList[i].Name + NAMESUFFIX,
                                                      NAMESPACE,
                                                      true);
            return regexes;
        }

        public class MyRegex
        {
            public string Name;
            public string Pattern;
            public RegexOptions Options;

            public MyRegex(string name, string pattern)
            {
                Name = name;
                Pattern = pattern;
                Options = RegexOptions.None;
            }

            public MyRegex(string name, string pattern, RegexOptions options)
            {
                Name = name;
                Pattern = pattern;
                Options = options;
            }
        }
    }
}
