using Domain.Shared;

namespace Domain.Tournament;

public abstract class MatchWinRule : Enumeration<MatchWinRule>
{
    private MatchWinRule(int value, string name) : base(value, name) { }

    public abstract int GamesToWin { get; }

    public static readonly MatchWinRule BestOf1 = new BestOf1MatchWinRule();
    public static readonly MatchWinRule BestOf3 = new BestOf3MatchWinRule();
    public static readonly MatchWinRule BestOf5 = new BestOf5MatchWinRule();
    public static readonly MatchWinRule BestOf7 = new BestOf7MatchWinRule();

    private class BestOf1MatchWinRule : MatchWinRule
    {
        public BestOf1MatchWinRule() : base(1, "BestOf1") { }
        public override int GamesToWin => 1;
    }

    private class BestOf3MatchWinRule : MatchWinRule
    {
        public BestOf3MatchWinRule() : base(2, "BestOf3") { }
        public override int GamesToWin => 2;
    }

    private class BestOf5MatchWinRule : MatchWinRule
    {
        public BestOf5MatchWinRule() : base(3, "BestOf5") { }
        public override int GamesToWin => 3;
    }

    private class BestOf7MatchWinRule : MatchWinRule
    {
        public BestOf7MatchWinRule() : base(4, "BestOf7") { }
        public override int GamesToWin => 4;
    }
}
