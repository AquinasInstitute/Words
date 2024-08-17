using Words.Words;

namespace Words.Addons;

public record Tackon: Addon
{
    public WordInfo TargetInfo { get; internal set; } = WordInfo.Null;
    
    public bool IsPackon { get; internal set; }
}