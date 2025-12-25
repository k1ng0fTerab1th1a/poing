using Domain.Match.Exceptions;
using Domain.Player;

namespace Domain.Match;

public record MatchId(int Value);

public class Match
{
    private readonly IList<Game> _games = [];

    private Match(PlayerId player1, PlayerId player2, int gamesToWin)
    {
        Player1 = player1;
        Player2 = player2;
        GamesToWin = gamesToWin;
    }

    public MatchId? Id { get; private set; }
    public PlayerId Player1 { get; private set; }
    public PlayerId Player2 { get; private set; }
    public int GamesToWin { get; private set; }
    public IReadOnlyCollection<Game> Games => _games.OrderBy(g => g.OrderInMatch).ToList().AsReadOnly();
    private bool IsFinished => Winner != null;

    public PlayerId? Winner
    {
        get
        {
            if (_games.Count(g => g.Winner == Player1) == GamesToWin)
            {
                return Player1;
            }
            if (_games.Count(g => g.Winner == Player2) == GamesToWin)
            {
                return Player2;
            }
            return null;
        }
    }

    public void AddGame(int player1Score, int player2Score)
    {
        if (IsFinished)
        {
            throw MatchException.MatchIsFinished();
        }
        _games.Add(Game.Create(Score.Create(player1Score), Score.Create(player2Score), _games.Count, this));
    }

    public void UpdateGame(int gameOrder, int player1Score, int player2Score)
    {

    }

    internal static Match Create(PlayerId player1, PlayerId player2, int gamesToWin)
    {
        if (gamesToWin < 1)
        {
            throw InvalidGamesToWinException.NotPositive(gamesToWin);
        }

        return new Match(player1, player2, gamesToWin);
    }
}
