using Domain.Shared;

namespace Domain.Tournament.Format;

public abstract class TournamentFormat : Enumeration<TournamentFormat>
{
    protected internal TournamentFormat(int value, string name) : base(value, name) { }

    internal abstract IList<PlannedMatch> GenerateMatches(Tournament tournament);

    public static readonly TournamentFormat RoundRobin = new RoundRobinTournamentFormat();
}
