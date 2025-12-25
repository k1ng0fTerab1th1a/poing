using Domain.Player;
using Domain.Match.Exceptions;

namespace Domain.Match;

public record Score
{
    private Score(int score)
    {
        Value = score;
    }

    public int Value { get; }

    public static Score Create(int score)
    {
        if (score < 0)
        {
            throw InvalidScoreException.Negative(score);
        }

        return new Score(score);
    }
}
