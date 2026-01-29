using Domain.Match.Exceptions;
using Domain.Player;

namespace Domain.Match;

public record GameId(int Value);

public class Game
{
    private const int MIN_SCORE_DIFFERENCE = 2;
    private const int POINTS_TO_WIN = 11;

    private Game(Score player1Score, Score player2Score, int orderInMatch, Match match)
    {
        Player1Score = player1Score;
        Player2Score = player2Score;
        OrderInMatch = orderInMatch;
        Match = match;
    }

    public GameId? Id { get; private set; }
    public Score Player1Score { get; private set; }
    public Score Player2Score { get; private set; }
    public int OrderInMatch { get; private set; } // one-based
    public Match Match { get; private set; }

    internal PlayerId Winner => Player1Score.Value > Player2Score.Value ? Match.Player1 : Match.Player2;

    internal void SetScore(Score player1Score, Score player2Score)
    {
        ValidateScore(player1Score, player2Score);
        Player1Score = player1Score;
        Player2Score = player2Score;
    }

    internal void DecrementOrder()
    {
        if (OrderInMatch == 1)
        {
            throw InvalidOrderInMatchException.CannotChange(OrderInMatch, OrderInMatch - 1);
        }

        OrderInMatch--;
    }

    internal static Game Create(Score player1Score, Score player2Score, int orderInMatch, Match match)
    {
        if (orderInMatch < 1)
        {
            throw InvalidOrderInMatchException.NotPositive(orderInMatch);
        }
        ValidateScore(player1Score, player2Score);

        return new Game(player1Score, player2Score, orderInMatch, match);
    }

    private static void ValidateScore(Score score1, Score score2)
    {
        if (score1.Value < POINTS_TO_WIN && score2.Value < POINTS_TO_WIN)
        {
            throw InvalidScoreException.NoWinner(score1.Value, score2.Value, POINTS_TO_WIN);
        }
        if (Math.Abs(score1.Value - score2.Value) < MIN_SCORE_DIFFERENCE)
        {
            throw InvalidScoreException.TooLittleDifference(score1.Value, score2.Value, MIN_SCORE_DIFFERENCE);
        }
        if ((score1.Value > POINTS_TO_WIN || score2.Value > POINTS_TO_WIN) && Math.Abs(score1.Value - score2.Value) > MIN_SCORE_DIFFERENCE)
        {
            throw InvalidScoreException.TooManyPoints(score1.Value, score2.Value);
        }
    }
}
