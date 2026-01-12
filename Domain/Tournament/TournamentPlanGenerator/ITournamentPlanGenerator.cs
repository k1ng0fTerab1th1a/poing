namespace Domain.Tournament.TournamentPlanGenerator;

public interface ITournamentPlanGenerator
{
    public IList<PlannedMatch> GenerateMatches(Tournament tournament);
}
