namespace Domain.Tournament;

public sealed record TournamentFormat
{
    private readonly byte _value;
    private TournamentFormat(byte value)
    {
        _value = value;
    }

    public static readonly TournamentFormat RoundRobin = new(0);
}
