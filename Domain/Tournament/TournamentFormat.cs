using Domain.Shared;

namespace Domain.Tournament;

public class TournamentFormat : Enumeration<TournamentFormat>
{
    private TournamentFormat(int value, string name) : base(value, name) { }

    public static readonly TournamentFormat RoundRobin = new(1, "RoundRobin");
}
