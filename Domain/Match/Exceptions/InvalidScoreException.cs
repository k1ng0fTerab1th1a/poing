using Domain.Shared;

namespace Domain.Match.Exceptions;

public class InvalidScoreException : DomainException
{
    private InvalidScoreException(string message) : base(message) { }

    internal static InvalidScoreException Negative(int score)
    {
        return new InvalidScoreException($"{score} is not a valid score: it must be non-negative.");
    }

    internal static InvalidScoreException NoWinner(int score1, int score2, int pointsToWin)
    {
        return new InvalidScoreException($"{score1}:{score2} is not a valid score:" +
            $" no one has {pointsToWin} or more points.");
    }

    internal static InvalidScoreException TooLittleDifference(int score1, int score2, int minDifference)
    {
        return new InvalidScoreException($"{score1}:{score2} is not a valid score:" +
            $" score difference is less than {minDifference}.");
    }

    internal static InvalidScoreException TooManyPoints(int score1, int score2)
    {
        return new InvalidScoreException($"{score1}:{score2} is not a valid score:" +
            $" one of the players has too many points.");
    }
}
