namespace Domain.Tournament;

public record TournamentFormat
{
    private static readonly Dictionary<int, TournamentFormat> _allByValue;
    private static readonly Dictionary<string, TournamentFormat> _allByName;

    static TournamentFormat()
    {
        TournamentFormat[] _all = [RoundRobin];
        _allByValue = _all.ToDictionary(x => x.Value);
        _allByName = _all.ToDictionary(x => nameof(x));
    }

    private TournamentFormat(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public static readonly TournamentFormat RoundRobin = new(1);

    public static TournamentFormat? FromValue(int value)
    {
        return _allByValue.GetValueOrDefault(value);
    }

    public static TournamentFormat? FromName(string name)
    {
        return _allByName.GetValueOrDefault(name);
    }
}
