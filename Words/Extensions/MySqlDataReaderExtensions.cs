using MySqlConnector;

namespace Words.Extensions;

public static class MySqlDataReaderExtensions
{
    public static string? GetStringOrNull(this MySqlDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);
        return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
    }
    
    public static char? GetCharOrNull(this MySqlDataReader reader, string columnName)
    {
        var ordinal = reader.GetOrdinal(columnName);
        return reader.IsDBNull(ordinal) ? null : reader.GetChar(ordinal);
    }
}