using System;
using System.Collections.Generic;
using System.Linq;

namespace CallTracker.Helpers
{
    public static class EnumList
    {
        public static IEnumerable<KeyValuePair<T, string>> Of<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<T, string>(p, p.ToString()))
                .ToList();
        }
    }

    public static class EnumerationExtensions
    {

        public static bool Has<T>(this System.Enum type, T value)
        {
            try
            {
                return (((int)(object)type & (int)(object)value) == (int)(object)value);
            }
            catch
            {
                return false;
            }
        }

        public static bool Is<T>(this System.Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNot<T>(this System.Enum type, T value)
        {
            try
            {
                return (int)(object)type != (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        public static T Add<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type | (int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not append value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }


        public static T Remove<T>(this System.Enum type, T value)
        {
            try
            {
                return (T)(object)(((int)(object)type & ~(int)(object)value));
            }
            catch (Exception ex)
            {
                throw new ArgumentException(
                    string.Format(
                        "Could not remove value from enumerated type '{0}'.",
                        typeof(T).Name
                        ), ex);
            }
        }

        public static T Change<T>(this System.Enum type, T value, bool action)
        {
            if (action)
                return (T)type.Add(value);
            else
                return (T)type.Remove(value);
        }

    }
}
