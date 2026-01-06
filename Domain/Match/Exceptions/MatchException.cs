using Domain.Shared;

namespace Domain.Match.Exceptions;

public class MatchException : DomainException
{
    private MatchException(string message) : base(message) { }

    internal static MatchException MatchIsFinished()
    {
        return new MatchException("Cannot add new game: the match is already finished.");
    }

    internal static MatchException GameNotFound(int gameOrder)
    {
        return new MatchException($"Game #{gameOrder} in match not found");
    }
}
