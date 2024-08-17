namespace Words.Tricks;

public record Syncope(string Explanation, string Before, string After)
{
    public string Explanation { get; } = Explanation;
    public string Before { get; } = Before;
    public string After { get; } = After;

    public override string ToString()
    {
        return $"{Explanation} ({Before} => {After})";
    }
}