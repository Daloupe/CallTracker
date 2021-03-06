﻿using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RegexAssembly
{
    public class CreateRegexAssembly
    {
        private static readonly AssemblyName ASSEMBLYNAME =
            new AssemblyName("RegexLib, Version=1.0.0.1001, Culture=neutral, PublicKeyToken=null");

        private static readonly string NAMESUFFIX = "Pattern";
        private static readonly string NAMESPACE = "Utilities.RegularExpressions";

        public static void Main()
        {
            var RegexList = new List<MyRegex>
            {
                //new MyRegex("Alpha",    @"[a-z\-\s\.]+", RegexOptions.IgnoreCase),
                //new MyRegex("AlphaNum", @"[a-z\d\-\s]+", RegexOptions.IgnoreCase),
                //new MyRegex("Digit",    @"[\d\-\s\.]+"),
                new MyRegex("Username",
                    @"^(?(?=[A-Z])[A-Z]+[A-Z\d._]*[A-Z\d]+|[a-z]+[a-z\d._]*[a-z\d]+)(?:@optusnet.com.au)?$"),
                //new MyRegex("UsernameLower", @"^[a-z]+[a-z\d._]*[a-z\d]+(?:@optusnet.com.au)?$"),
                //new MyRegex("UsernameUpper", @"^[A-Z]+[A-Z\d._]*[A-Z\d]+(?:@optusnet.com.au)?$"),
                new MyRegex("BRAS", @"^[a-z]{3}\d{3}\.[a-z]{2}$"),
                new MyRegex("CommonNBN", @"^(?<Type>[AVCSNIGPRT]{3})" + // Data Type
                                         @"(?<Id>\d{12})$" // Id
                    , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
                new MyRegex("Mobile", @"^(0|61)" + // Prefix
                                      @"(?<Number>4\d{8})$"
                    , RegexOptions.ExplicitCapture), // Number
                new MyRegex("DN", @"^(0|61)" + // Prefix
                                  @"(?<DN>(?<State>[2378])" + // State
                                  @"(?<Area>\d)" + // Area
                                  @"(?<Number>\d{7})$)" // Number
                    , RegexOptions.ExplicitCapture),
                new MyRegex("Node", @"^(?<State>\d{2})" +
                                    @"(?<CMTS>[a-z]{2})" +
                                    @"_?" +
                                    @"(?<Node>\d{3})$"
                    , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
                new MyRegex("CMBS", @"^3?" +
                                    @"(?<State>[1-3])" + // State
                                    @"-?" + // Divider
                                    @"(?<Account>\d{6})" + // Account
                                    @"(-|0| )?" + // Divider
                                    @"(0)?(?(-1)(?<Flip>\d)|(?<Flip>\d)\d?)$" // Flip
                    , RegexOptions.ExplicitCapture),
                new MyRegex("ICON", @"^((?:1|5|8|9)\d{8})(\d{5})$"),
                new MyRegex("Name", @"(?:(Mr|Mrs|miss|dr)\.?)?\s?" + // Title (Followed by a ".")
                                    @"([a-z]+)" + // First Name
                                    @"(?:\s([a-z]))?" + // Middle Initial
                                    @"\s([a-z]+(?:(?:-)[a-z]+)?)" // Surnames
                    , RegexOptions.IgnoreCase),
                new MyRegex("Address", @"^  (
                                                ((?<PropertyType>[a-z\ ,\.']+?)\ *?)?
                                                ((?<Unit>\d+)(,|/|-|[\ ]*?))?
                                                (\b(?<Number>\d+[a-z]?)\b)\ *?
                                                (?<Street>[\w\ '-]+)
                                                (\b(?<StreetType>STREET|ST|ROAD|RD|GROVE|GR|DRIVE|DR|AVENUE|AVE|CIRCUIT|CCT|CLOSE|CL|COURT|CRT|CT|CRESCENT|CRES|PLACE|PL|PARADE|PDE|BOULEVARD|BLVD|HIGHWAY|HWY|ALLEY|ALLY|APPROACH|APP|ARCADE|ARC|BROW|BYPASS|BYPA|CAUSEWAY|CWAY|CIRCUS|CIRC|COPSE|CPSE|CORNER|CNR|COVE|END|ESPLANANDE|ESP|FLAT|FREEWAY|FWAY|FRONTAGE|FRNT|GARDENS|GDNS|GLADE|GLD|GLEN|GREEN|GRN|HEIGHTS|HTS|LANE|LINK|LOOP|MALL|MEWS|PACKET|PCKT|PARK|PARKWAY|PKWY|PROMENADE|PROM|RESERVE|RES|RIDGE|RDGE|RISE|ROW|SQUARE|SQ|STRIP|STRP|TARN|TERRACE|TCE|THOROUGHFARE|TFRE|TRACK|TRAC|TRUNKWAY|TWAY|VIEW|VISTA|VSTA|WALK|WAY|WALKWAY|WWAY|YARD)\b).?,?\ *?
                                            )
                                            ((?<Suburb>[a-z'.]+([\-,\ ]+[a-z'.]+)*?),?\ *?)?
                                            (\b(?<State>New\ South\ Wales|NSW|Victoria|VIC|Queensland|QLD|Australian\ Capital\ Territory|ACT|South\ Australia|SA|West\ Australia|WA|Tasmania|TAS|Northern\ Territory|NT)\b,?\ *?)?
                                            ((?<Postcode>\d{4}),?\ *?)?
                                            (Au(s(tralia)?)?)?
                                            (\s(?=[^$]))* 
                                         $"
                    , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace),
                new MyRegex("ITCase", @"^(?<Year>1[4-6])" +
                                      @"(?<Month>(0\d|1[0-2]))" +
                                      @"(?<Day>(0\d|[1-2]\d|3[0-1]))" +
                                      @"(?<Id>\d{4})$"
                    , RegexOptions.ExplicitCapture),
                new MyRegex("MAC", @"^(?<Id>(([0-9A-F]{2})(-|:)?){6})\b"
                    , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
                new MyRegex("AddressId", @"^(\d{7})$"),
                new MyRegex("ESN", @"^((\d|[a-z]){5})$", RegexOptions.IgnoreCase),
                new MyRegex("NTDSN", @"^(\d{12})$", RegexOptions.IgnoreCase),
                new MyRegex("GSID", @"^(\d{16})$", RegexOptions.IgnoreCase),
                new MyRegex("IP", @"^([0-2]?\d?\d\.){3}([0-2]?\d?\d)$", RegexOptions.IgnoreCase),
            };
            
            Regex.CompileToAssembly(CreateCompilationInfo(RegexList), ASSEMBLYNAME);
        }

        private static RegexCompilationInfo[] CreateCompilationInfo(List<MyRegex> regexList)
        {
            var regexes = new RegexCompilationInfo[regexList.Count];

            for (var i = 0; i < regexList.Count; i++)
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





                //new MyRegex("Address2", @"(?:(Unit|Lot|Level|Floor|P.?O.? Box)\s)?" +  // Property Type
                //                        @"(?:(\d+)(?:/|\\|\s))?" +         // Unit Number
                //                        @"(\d+)" +                          // Property Number
                //                        @"\s*([a-z]+(?:(?:\s|-)[a-z]+)?)" +                     // Street Name
                //                        @"\s*(st|rd|ave|hwy|cct|ct|cl|gr|street|road|avenue|highway|circuit|court|close|grove)\.?" +                  // Street Type
                //                        @"\s*([a-z]+(?:(?:\s|-)[a-z]+)?)" +                     // Suburb
                //                        @"\s*(Victoria|Tasmania|Queensland|New South Wales|(?:South|Western) Australia|(?:Northern|Australian Capital) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)?" +           // State (Optional)
                //                        @"\s*(\d{4})?"                      // Postcode (Optional)



//new MyRegex("Address", @"^((?<PropertyType>Unit|Lot|Level|Floor|P.?O.? Box)\b)?" + // Property Type
//                       @"\s*((?<Unit>\d+)(/|\\|-| ))?" + // Unit Number
//                       @"\s*(?<Number>\d+)" + // Property Number
//                       @"\s*(?<Street>[a-z]+((\s*|-?)[a-z]+)*?)" + // Street Name
//                       @"\s*(?<StreetType>st|rd|dr|ave|hwy|cct|ct|cl|gr|street|road|drive|avenue|highway|circuit|court|close|grove)\.?" +
//                       // Street Type
//                       @"\s*(?<Suburb>[a-z]+(((\s*|-?)[a-z]+){1,2}?)?)?.*" // Suburb                 
//    , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),
//new MyRegex("Address2", @"^((?<PropertyType>Unit|Lot|Level|Floor|P.?O.? Box)\b)?" + // Property Type
//                        @"\s*((?<Unit>\d+)(/|\\|-| ))?" + // Unit Number
//                        @"\s*(?<Number>\d+)" + // Property Number
//                        @"\s*(?<Street>[a-z]+((\s*|-?)[a-z]+)*)" + // Street Name
//                        @"\s*(?<StreetType>st|rd|dr|ave|hwy|cct|ct|cl|gr|street|road|drive|avenue|highway|circuit|court|close|grove)\.?" +
//                        // Street Type
//                        @"\s*(?<Suburb>[a-z]+(?(?=\s*(Victoria|Tasmania|Queensland|New South Wales|(South|Western) Australia|(Northern|Australian Capital) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)\b)|(\s*|-?)[a-z]+)*)?" +
//                        // Suburb    
//                        @"\s*(?<State>Victoria|Tasmania|Queensland|New South Wales|(South|Western) Australia|(Northern|Australian Capital) Territory|VIC|NSW|SA|WA|NT|TAS|ACT|QLD)?" +
//                        // State (Optional)
//                        @"\s*(?<Postcode>\d{4})?" // Postcode (Optional)
//    , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture),