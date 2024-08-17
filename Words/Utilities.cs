using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Words.Tests")]
namespace Words;

internal static class Utilities
{
    public static string EscapeQuotes(string text)
    {
        return text.Replace("\\", @"\\").Replace("\"", "\\\"");
    }

    public static string EscapeCharacter(char character)
    {
        return character == '\'' ? "\\\'" : character.ToString();
    }
}