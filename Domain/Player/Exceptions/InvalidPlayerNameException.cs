using Domain.Shared;

namespace Domain.Player.Exceptions;

public class InvalidPlayerNameException : DomainException
{
    private InvalidPlayerNameException(string message) : base(message) { }

    internal static InvalidPlayerNameException Blank()
    {
        return new InvalidPlayerNameException("Player name may not be blank.");
    }

    internal static InvalidPlayerNameException TooLong(string playerName)
    {
        return new InvalidPlayerNameException($"Player name {playerName} is too long.");
    }

    internal static InvalidPlayerNameException TooShort(string playerName)
    {
        return new InvalidPlayerNameException($"Player name {playerName} is too short.");
    }
}
