namespace Domain.Tournament;

public record MatchWinRule
{
    private static readonly Dictionary<int, MatchWinRule> _allByValue;
    private static readonly Dictionary<string, MatchWinRule> _allByName;

    static MatchWinRule()
    {
        MatchWinRule[] _all = [BestOf1, BestOf3, BestOf5, BestOf7];
        _allByValue = _all.ToDictionary(x => x.GamesToWin);
        _allByName = _all.ToDictionary(x => nameof(x));
    }

    private MatchWinRule(int gamesToWin)
    {
        GamesToWin = gamesToWin;
    }

    public int GamesToWin { get; }

    public static readonly MatchWinRule BestOf1 = new(1);
    public static readonly MatchWinRule BestOf3 = new(2);
    public static readonly MatchWinRule BestOf5 = new(3);
    public static readonly MatchWinRule BestOf7 = new(4);

    public static MatchWinRule? FromValue(int value)
    {
        return _allByValue.GetValueOrDefault(value);
    }

    public static MatchWinRule? FromName(string name)
    {
        return _allByName.GetValueOrDefault(name);
    }
}
