using System.Collections.Generic;

namespace Lackluster
{
    public static class GuardExtensions
    {
        /// <summary>
        /// Guards against null references exceptions by ensuring the object always exists.
        /// </summary>
        public static IEnumerable<T> Guard<T>(this IEnumerable<T> list)
        {
            return list ?? new T[] { };
        }

        /// <summary>
        /// Guards against null references exceptions by ensuring the object always exists.
        /// </summary>
        public static Dictionary<TKey, TValue> Guard<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            return dict ?? new Dictionary<TKey, TValue>();
        }
    }
}