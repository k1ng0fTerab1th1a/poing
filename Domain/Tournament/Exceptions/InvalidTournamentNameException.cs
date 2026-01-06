using Domain.Shared;

namespace Domain.Tournament.Exceptions;

public class InvalidTournamentNameException : DomainException
{
    private InvalidTournamentNameException(string message) : base(message) { }

    internal static InvalidTournamentNameException Blank()
    {
        return new InvalidTournamentNameException("Tournament name may not be blank.");
    }

    internal static InvalidTournamentNameException TooLong(string tournamentName)
    {
        return new InvalidTournamentNameException($"Tournament name {tournamentName} is too long.");
    }

    internal static InvalidTournamentNameException TooShort(string tournamentName)
    {
        return new InvalidTournamentNameException($"Tournament name {tournamentName} is too short.");
    }
}
