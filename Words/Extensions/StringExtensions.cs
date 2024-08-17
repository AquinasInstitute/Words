namespace Words.Extensions;

public static class StringExtensions
{
    public static string ReplaceFirst(this string value, string before, string after)
    {
        var index = value.IndexOf(before, StringComparison.Ordinal);
        if (index == -1) return value;
        
        var sliceBefore = value[..index];
        var sliceAfter = value[(index + before.Length)..];

        return sliceBefore + after + sliceAfter;
    }
}