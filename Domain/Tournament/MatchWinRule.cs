namespace Domain.Tournament;

public sealed record MatchWinRule
{
    private MatchWinRule(int gamesToWin)
    {
        GamesToWin = gamesToWin;
    }

    public int GamesToWin { get; }

    public static readonly MatchWinRule BestOf1 = new(1);
    public static readonly MatchWinRule BestOf3 = new(2);
    public static readonly MatchWinRule BestOf5 = new(3);
    public static readonly MatchWinRule BestOf7 = new(4);
}
