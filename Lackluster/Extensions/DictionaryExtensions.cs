using System.Collections.Generic;

namespace Lackluster
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Overwrites the key with the given value, if it exists.
        /// </summary>
        public static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }

            dict.Add(key, value);
        }

        /// <summary>
        /// Allows chaining the dictionary's .Set method.
        /// </summary>
        public static Dictionary<TKey, TValue> ChainSet<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict.Set(key, value);

            return dict;
        }

        /// <summary>
        /// Allows chaining the dictionary's .Remove method.
        /// </summary>
        public static Dictionary<TKey, TValue> ChainRemove<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            dict.Remove(key);

            return dict;
        }

        /// <summary>
        /// Allows chaining the dictionary's .Add method.
        /// </summary>
        public static Dictionary<TKey, TValue> ChainAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict.Add(key, value);

            return dict;
        }
    }
}