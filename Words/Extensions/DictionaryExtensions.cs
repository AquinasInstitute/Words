namespace Words.Extensions;

internal static class DictionaryExtensions
{
    public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> fallback) where TKey : notnull
    {
        if (dictionary.TryGetValue(key, out var result))
        {
            return result;
        }

        var value = fallback();
        dictionary.Add(key, value);

        return value;
    }

    public static List<TValue> GetOrEmpty<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary, TKey key) where TKey : notnull
    {
        return dictionary.TryGetValue(key, out var value) ? value : EmptyLists<TValue>.Value;
    }

    internal static class EmptyLists<T>
    {
        public static readonly List<T> Value = [];
    }
}