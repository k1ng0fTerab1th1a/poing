using Domain.Match.Exceptions;
using Domain.Player;

namespace Domain.Tournament.TournamentPlanGenerator;

public record PlannedMatch
{
    private PlannedMatch(PlayerId player1, PlayerId player2, int gamesToWin, int numberInTournament)
    {
        Player1 = player1;
        Player2 = player2;
        GamesToWin = gamesToWin;
        NumberInTournament = numberInTournament;
    }

    public PlayerId Player1 { get; }
    public PlayerId Player2 { get; }
    public int GamesToWin { get; }
    public int NumberInTournament { get; }

    internal static PlannedMatch Create(PlayerId player1, PlayerId player2, int gamesToWin, int numberInTournament)
    {
        if (gamesToWin < 1)
        {
            throw InvalidGamesToWinException.NotPositive(gamesToWin);
        }
        if (numberInTournament < 1)
        {
            throw InvalidNumberInTournamentException.NotPositive(numberInTournament);
        }

        return new PlannedMatch(player1, player2, gamesToWin, numberInTournament);
    }
}
