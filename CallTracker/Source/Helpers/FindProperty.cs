using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using CallTracker.Model;
using Utilities.RegularExpressions;

namespace CallTracker.Helpers
{
    public static class FindProperty
    {
        // Object Methods ///////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Splits path by the context'^', then by alternates',', then finds the value of the first property that doesn't return null.
        /// '|' can be used to signify a Regex replace, '+' will concatenate extra data types.
        /// </summary>
        public static string FollowPropertyPath(object value, string path, string context)
        {
            var data = path.Split('^');
            if (data.Length > 1)
            {
                var match = data.FirstOrDefault(d => d.StartsWith(context));
                data = (String.IsNullOrEmpty(match) ? data[1].Remove(0, 3) : match.Remove(0, 3)).Split(',');
            }
            else
                data = (path.StartsWith("^") ? data[0].Remove(0, 3) : data[0]).Split(',');

            return FollowPropertyPath(value, data);
        }

        public static string FollowPropertyPath(object value, string[] path)
        {
            var output = String.Empty;

            for (var x = 0; x < path.Count(); ++x)
            {
                output = FollowPropertyPath(value, path[x]);
                if (!String.IsNullOrEmpty(output)) break;
            }

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
            if (value == null)
            {
                EventLogger.LogNewEvent("FindProperty Error: Object is Null");
                return String.Empty;
            }
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
            private readonly string _replacePattern;
            private Regex _pattern;

            public PathRegex(string path)
            {
                var split = path.Split('|');
                Path = split[0].Trim().Split('.');
                if (split.Length > 1)
                    _replacePattern = split[1].TrimStart(' ');
            }

            public bool HasRegex()
            {
                return !String.IsNullOrEmpty(_replacePattern);
            }

            public string RegexReplace(string input)
            {
                if (RegexLookup.ContainsKey(Path.Last()))
                    _pattern = RegexLookup[Path.Last()];
                else
                    return "Error: No Regex found for data.";
                return _pattern.Replace(input, _replacePattern);
            }
        }

        private static readonly CommonNBNPattern CommonNBNPattern = new CommonNBNPattern();
        static readonly Dictionary<string, Regex> RegexLookup = new Dictionary<string, Regex>{
            {"CMBS", new CMBSPattern()},
            {"Name", new NamePattern()},
            {"DN", new DNPattern()},
            {"Mobile", new MobilePattern()},
            {"ICON", new ICONPattern()},
            {"Username", new UsernamePattern()},
            {"AVC", CommonNBNPattern},
            {"CVC", CommonNBNPattern},
            {"CSA", CommonNBNPattern},
            {"NNI", CommonNBNPattern},
            {"PRI", CommonNBNPattern},
            {"APT", CommonNBNPattern},
            {"INC", CommonNBNPattern},
            {"GSID", new GSIDPattern()}  
        };

        public static List<string> GetLists(string[] lists, Type datasource)
        {
            var aggregateList = new List<string>();
            foreach (var myfield in lists.Select(list => datasource.GetField(list, BindingFlags.Static | BindingFlags.Public)))
            {
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