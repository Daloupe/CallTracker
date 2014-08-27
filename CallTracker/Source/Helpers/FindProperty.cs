using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public static string FollowPropertyPath(object value, string[] path)
        {
            var output = String.Empty;
            var x = 0;

            while (String.IsNullOrEmpty(output))
            {
                output = FollowPropertyPath(value, path[x]);
                ++x;
            }

            return output;
        }
        
        // Deprecated
        public static string FollowPropertyPath(object value, string path, string altPath)
        {
            var output = FollowPropertyPath(value, path);

            if (String.IsNullOrEmpty(output) && !String.IsNullOrEmpty(altPath))
                output = FollowPropertyPath(value, altPath);

            return output;
        }
        
        public static string FollowPropertyPath(object value, string path)
        {
            if (String.IsNullOrEmpty(path))
                return null;

            var output = String.Empty;
            var dataSplit = new DataSplit(path);

            foreach (var pathSplit in dataSplit.Data)
                output += GetPropertyFromPath(value, pathSplit);

            return output;
        }

        private static string GetPropertyFromPath(object value, PathRegex pathSplit)
        {
            var output = value;
            var currentType = output.GetType();

            foreach (string propertyName in pathSplit.Path)
            {
                var property = currentType.GetProperty(propertyName);
                if (property == null) continue;
                output = property.GetValue(output, null);
                currentType = property.PropertyType;
            }

            if (pathSplit.HasRegex())
                output = pathSplit.RegexReplace(output.ToString());
            
            return output == null ? String.Empty : output.ToString();
        }

        public static void SetPropertyFromPath(object obj, string path, object value)
        {
            var output = obj;
            var currentType = output.GetType();
            var pathSplit = path.Split('.');
            foreach (string propertyName in pathSplit)
            {
                var property = currentType.GetProperty(propertyName);
                if (property == null) continue;
                if (propertyName == pathSplit.LastOrDefault())
                {
                    property.SetValue(output, value, null);
                    break;
                }
                output = property.GetValue(output, null);
                currentType = property.PropertyType;
            }
        }


        public class DataSplit
        {
            public List<PathRegex> Data = new List<PathRegex>();

            public DataSplit(string _data)
            {
                string[] split = _data.Split('+');
                foreach(var path in split)
                    Data.Add(new PathRegex(path));
            }
        }

        public class PathRegex
        {
            public string[] Path;
            private string ReplacePattern;
            private Regex Pattern;

            public PathRegex(string path)
            {
                string[] split = path.Split('|');
                Path = split[0].Trim().Split('.');
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
                else
                    return "Error: No Regex found for data.";
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