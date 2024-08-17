using System.Text;

namespace Words.Extensions;

internal static class IoExtensions
{
    // Reusing the same buffer is 25% faster.
    [ThreadStatic]
    private static StringBuilder? _buffer;
    
    private static bool IsWhiteSpace(char character) => character is ' ' or '\t' or '\r' or '\n';
    
    /// <summary>
    /// Reads a single whitespace prefixed integer.
    /// </summary>
    /// <param name="file">The file to read from.</param>
    /// <returns>The resulting integer.</returns>
    public static int ReadInteger(this StreamReader file)
    {
        _buffer ??= new StringBuilder();
        
        var value = 0;
        var readingWhitespace = true;

        while (true)
        {
            var rawCharacter = file.Read();
            if (rawCharacter == -1) break;

            var character = (char)rawCharacter;

            if (IsWhiteSpace(character) && !readingWhitespace) break;
            if (IsWhiteSpace(character)) continue;
            
            readingWhitespace = false;

            if (!char.IsBetween(character, '0', '9'))
            {
                throw new FormatException($"The character '${Utilities.EscapeCharacter(character)}' is not a valid digit.");
            }

            value = value * 10 + (character - '0');
        }

        return value;
    }
    
    /// <summary>
    /// Reads a single whitespace prefixed string that itself contains no whitespace.
    /// </summary>
    /// <param name="file">The file to read from.</param>
    /// <returns>The resulting string.</returns>
    public static string ReadString(this StreamReader file)
    {
        _buffer ??= new StringBuilder();
        
        var readingWhitespace = true;

        while (true)
        {
            var rawCharacter = file.Read();
            if (rawCharacter == -1) break;

            var character = (char)rawCharacter;

            if (IsWhiteSpace(character) && !readingWhitespace) break;
            if (IsWhiteSpace(character)) continue;
            
            readingWhitespace = false;
            _buffer.Append(character);
        }

        var result = _buffer.ToString();
        _buffer.Clear();
        return result;
    }
    public static string ReadString(this StreamReader file, int limit)
    {
        _buffer ??= new StringBuilder();
        
        var readingWhitespace = true;
        var charsToRead = limit;
        
        while (charsToRead > 0)
        {
            charsToRead--;
            
            var rawCharacter = file.Read();
            if (rawCharacter == -1) break;

            var character = (char)rawCharacter;

            if (IsWhiteSpace(character) && !readingWhitespace) continue;
            if (IsWhiteSpace(character)) continue;
            
            readingWhitespace = false;
            _buffer.Append(character);
        }

        var result = _buffer.ToString();
        _buffer.Clear();
        return result;
    }

    public static void SkipWhitespace(this StreamReader file)
    {
        while (IsWhiteSpace((char)file.Peek()))
        {
            file.Read();
        }
    }
}