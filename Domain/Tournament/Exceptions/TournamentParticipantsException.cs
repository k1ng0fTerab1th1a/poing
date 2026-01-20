using Domain.Shared;

namespace Domain.Tournament.Exceptions;

internal class TournamentParticipantsException : DomainException
{
    private TournamentParticipantsException(string message) : base(message) { }

    internal static TournamentParticipantsException AlreadyExists()
    {
        return new TournamentParticipantsException("Participant already exists.");
    }

    internal static TournamentParticipantsException ParticipantNotFound()
    {
        return new TournamentParticipantsException("Participant not found.");
    }
}
