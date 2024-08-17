using Words.Flags;

namespace Words.Inflected;

public abstract record InflectedDeclineable: InflectedForm
{
    public int Declension { get; internal init; }
    public int DeclensionVariant { get; internal init; }
    
    public Case Case { get; internal init; }
    public Number Number { get; internal init; }
    public Gender Gender { get; internal init; }
}