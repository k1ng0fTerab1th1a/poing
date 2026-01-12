namespace Domain.Tournament;

public record MatchWinRule
{
    private static readonly Dictionary<int, MatchWinRule> _all;

    static MatchWinRule()
    {
        _all = (new MatchWinRule[] { BestOf1, BestOf3, BestOf5, BestOf7 })
            .ToDictionary(x => x.GamesToWin);
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
        return _all.GetValueOrDefault(value);
    }
}
