using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

using Utilities.RegularExpressions;
using CallTracker.Data;

namespace CallTracker.Helpers
{
    public static class FindProperty
    {
        // Object Methods ///////////////////////////////////////////////////////////////////////////////////////
        public static string FollowPropertyPath(object _value, string _path)
        {
            if (String.IsNullOrEmpty(_path))
                return null;

            object output = _value;
            Type currentType = output.GetType();

            DataSplit pathSplit = new DataSplit(_path);

            foreach (string propertyName in pathSplit.Path)
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                if (property != null)
                {
                    output = property.GetValue(output, null);
                    currentType = property.PropertyType;
                }
            }

            if (pathSplit.HasRegex())
                output = pathSplit.RegexReplace(output.ToString());

            return output == null ? String.Empty : output.ToString();
        }

        public static string FollowPropertyPath(object _value, string _path, string _altPath)
        {
            string output = FollowPropertyPath(_value, _path);

            if (String.IsNullOrEmpty(output) && !String.IsNullOrEmpty(_altPath))
                output = FollowPropertyPath(_value, _altPath);

            return output;
        }

        public class DataSplit
        {
            public string[] Path;
            private string ReplacePattern;
            private Regex Pattern;

            public DataSplit(string path)
            {
                string[] split = path.Split('|');
                Path = split[0].TrimEnd(' ').Split('.');
                if (split.Length > 1)
                    ReplacePattern = split[1].TrimStart(' ');
            }

            public bool HasRegex()
            {
                return !String.IsNullOrEmpty(ReplacePattern);
            }

            public string RegexReplace(string input)
            {
                if (RegexLookup.ContainsKey(Path.Last()))
                    Pattern = RegexLookup[Path.Last()];
                return Pattern.Replace(input, ReplacePattern);
            }
        }

        static Dictionary<string, Regex> RegexLookup = new Dictionary<string, Regex>{
            {"CMBS", new CMBSPattern()},
            {"Name", new NamePattern()},
            {"DN", new DNPattern()},
            {"Mobile", new MobilePattern()}
        };

        public static List<string> GetLists(string[] lists, Type datasource)
        {
            FieldInfo myfield;
            List<string> aggregateList = new List<string>();
            foreach (var list in lists)
            {
                myfield = datasource.GetField(list, BindingFlags.Static | BindingFlags.Public);
                aggregateList.AddRange(((List<string>)myfield.GetValue(null)));
            }
            return aggregateList;
        }
    }

}













//public static string FollowPropertyPath(object _value, string _path, string _altPath)
//        {
//            if (String.IsNullOrEmpty(_path))
//                return null;

//            object output = _value;
//            Type currentType = output.GetType();

//            DataSplit pathSplit = new DataSplit(_path);

//            foreach (string propertyName in pathSplit.Path)
//            {
//                PropertyInfo property = currentType.GetProperty(propertyName);
//                if (property != null)
//                {
//                    output = property.GetValue(output, null);
//                    currentType = property.PropertyType;
//                }
//            }

//            if(pathSplit.HasRegex())
//                output = pathSplit.RegexReplace(output.ToString());

//            if (String.IsNullOrEmpty(output.ToString()) && !String.IsNullOrEmpty(_altPath))
//                output = FollowPropertyPath(_value, _altPath);

//            return output == null ? String.Empty : output.ToString();
//        }