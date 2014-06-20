using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CallTracker.Helpers
{
    static class FindProperty
    {
        // Object Methods ///////////////////////////////////////////////////////////////////////////////////////
        public static string FollowPropertyPath(object _value, string _path)
        {
           // Console.WriteLine(_path);
            if (String.IsNullOrEmpty(_path))
                return null;

            object output = _value;
            Type currentType = output.GetType();

            foreach (string propertyName in _path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                if (property != null)
                {
                    output = property.GetValue(output, null);
                    currentType = property.PropertyType;
                }
            }

            return output == null ? String.Empty : output.ToString();
        }

        public static string FollowPropertyPath(object _value, string _path, string _altPath)
        {
            if (String.IsNullOrEmpty(_path))
                return null;

            object output = _value;
            Type currentType = output.GetType();  

            foreach (string propertyName in _path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                if (property != null)
                {
                    output = property.GetValue(output, null);
                    currentType = property.PropertyType;
                }
            }

            if (String.IsNullOrEmpty(output.ToString()) && !String.IsNullOrEmpty(_altPath))
                output = FollowPropertyPath(_value, _altPath);

            return output == null ? String.Empty : output.ToString();
        }
    }
}
