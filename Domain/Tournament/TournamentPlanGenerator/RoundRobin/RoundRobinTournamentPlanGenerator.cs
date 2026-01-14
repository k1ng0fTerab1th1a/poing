using Domain.Player;

namespace Domain.Tournament.TournamentPlanGenerator.RoundRobin;

public class RoundRobinTournamentPlanGenerator : ITournamentPlanGenerator
{
    /// <summary>
    /// Implementation of <a href="https://en.wikipedia.org/wiki/Round-robin_tournament#Berger_tables">Berger tables</a>
    /// </summary>
    public IList<PlannedMatch> GenerateMatches(Tournament tournament)
    {
        IReadOnlyList<PlayerId> participants = tournament.Participants;
        int n = participants.Count;
        int nRotating = n % 2 == 0 ? n - 1 : n;
        int shift = (n + 1) / 2;
        int rounds = n % 2 == 0 ? n - 1 : n;
        IList<PlannedMatch> plan = [];

        for (int round = 0; round < rounds; round++)
        {
            if (n % 2 == 0)
            {
                if (round % 2 == 0)
                {
                    plan.Add(PlannedMatch.Create(
                        participants[(0 + round * shift) % nRotating],
                        participants[participants.Count - 1],
                        tournament.MatchWinRule.GamesToWin,
                        plan.Count + 1));
                }
                else
                {
                    plan.Add(PlannedMatch.Create(
                        participants[participants.Count - 1],
                        participants[(0 + round * shift) % nRotating],
                        tournament.MatchWinRule.GamesToWin,
                        plan.Count + 1));
                }
            }

            for (int i = 1; i <= nRotating / 2; i++)
            {
                plan.Add(PlannedMatch.Create(
                    participants[(i + round * shift) % nRotating],
                    participants[(nRotating - i + round * shift) % nRotating],
                    tournament.MatchWinRule.GamesToWin,
                    plan.Count + 1));
            }
        }
        return plan;
    }
}
