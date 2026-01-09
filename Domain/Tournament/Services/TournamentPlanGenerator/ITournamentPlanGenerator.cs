namespace Domain.Tournament.Services.TournamentPlanGenerator;

public interface ITournamentPlanGenerator
{
    public IList<PlannedMatch> GenerateMatches(Tournament tournament);
}
