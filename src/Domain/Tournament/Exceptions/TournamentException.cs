using Domain.Shared;

namespace Domain.Tournament.Exceptions;

internal class TournamentException : DomainException
{
    private TournamentException(string message) : base(message) { }

    internal static TournamentException AlreadyStarted()
    {
        return new TournamentException("Cannot proceed: the tournament already started.");
    }

    internal static TournamentException NotEnoughParticipants(int participants, int minParticipants)
    {
        return new TournamentException($"Cannot proceed: the tournament has {participants} participants, min {minParticipants} required.");
    }
}
