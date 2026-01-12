namespace Domain.Tournament;

public record TournamentFormat
{
    private static readonly Dictionary<int, TournamentFormat> _all;

    static TournamentFormat()
    {
        _all = (new TournamentFormat[] { RoundRobin })
            .ToDictionary(x => x.Value);
    }

    private TournamentFormat(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static readonly TournamentFormat RoundRobin = new(1);

    public static TournamentFormat? FromValue(int value)
    {
        return _all.GetValueOrDefault(value);
    }
}
