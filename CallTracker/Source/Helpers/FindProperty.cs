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
            if (String.IsNullOrEmpty(_path))
                return null;

            Type currentType = _value.GetType();

            foreach (string propertyName in _path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                if (property != null)
                {
                    _value = property.GetValue(_value, null);
                    currentType = property.PropertyType;
                }
            }

            return _value.ToString();
        }

        public static string FollowPropertyPath(object _value, string _path, string _altPath)
        {
            if (String.IsNullOrEmpty(_path))
                return null;

            Type currentType = _value.GetType();
            object output = _value;

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

            return output.ToString();
        }
    }
}
