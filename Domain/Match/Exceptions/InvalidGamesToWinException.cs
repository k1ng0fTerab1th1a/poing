using Domain.Shared;

namespace Domain.Match.Exceptions;

public class InvalidGamesToWinException : DomainException
{
    private InvalidGamesToWinException(string message) : base(message) { }

    internal static InvalidGamesToWinException NotPositive(int gamesToWin)
    {
        return new InvalidGamesToWinException($"{gamesToWin} is not a valid number of games to win the match: it must be positive.");
    }
}
