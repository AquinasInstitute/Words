namespace Words.Words;

public record CombinedPronoun: Pronoun
{
    public (int declension, int variant)[] Declensions = Array.Empty<(int, int)>();
    public Word[] Underlying = Array.Empty<Word>();
}