using Domain.Shared;

namespace Domain.Match.Exceptions;

public class InvalidNumberInTournamentException : DomainException
{
    private InvalidNumberInTournamentException(string message) : base(message) { }

    internal static InvalidNumberInTournamentException NotPositive(int numberInTournament)
    {
        return new InvalidNumberInTournamentException($"{numberInTournament} is not a valid number in tournament for a match: it must be positive.");
    }
}
