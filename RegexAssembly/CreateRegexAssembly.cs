using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RegexAssembly
{
    public class CreateRegexAssembly
    {
        public static readonly AssemblyName ASSEMBLYNAME = new AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");
        public const string NAMESUFFIX = "Pattern";
        public const string NAMESPACE = "Utilities.RegularExpressions";

        public static void Main()
        {
            List<MyRegex> RegexList = new List<MyRegex>
            {
                new MyRegex("Name", @"(\b[A-Z][a-z]+(-|\s)?){2,}", RegexOptions.IgnoreCase),
                new MyRegex("UsernameLower", @"\A[a-z]+[a-z0-9._]*[a-z0-9]+(@optusnet.com.au)?\Z"),
                new MyRegex("UsernameUpper", @"\A[A-Z]+[A-Z0-9._]*[A-Z0-9]+(@optusnet.com.au)?\Z"),
                new MyRegex("Address", @"\w+", RegexOptions.IgnoreCase),
                new MyRegex("BRAS", @"\A[a-z]{3}\d{3}\.[a-z]{2}\Z"),
                new MyRegex("CommonNBN", @"\A[AVCSNIG]{3}\d{12}\Z"),
                new MyRegex("Mobile", @"^(0|61)4\d{8}$"),
                new MyRegex("DN", @"^(0|61)[2378]\d{8}$"),
                new MyRegex("Node", @"^\d\d(?i)[A-Z]{2}_?\d\d\d\z"),
                new MyRegex("CMBS", @"\A3[1-3]-??\d{5}(-|0|\s)\d\z"),
                new MyRegex("ICON", @"\A(1|5|8|9)\d{13}\z")
            };

            Regex.CompileToAssembly(CreateCompilationInfo(RegexList), ASSEMBLYNAME);
        }

        public static RegexCompilationInfo[] CreateCompilationInfo(List<MyRegex> regexList)
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
