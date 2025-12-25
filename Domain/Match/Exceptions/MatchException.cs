using Domain.Shared;

namespace Domain.Match.Exceptions;

public class MatchException : DomainException
{
    private MatchException(string message) : base(message) { }

    internal static MatchException MatchIsFinished()
    {
        return new MatchException("Can not add new game: the match is already finished.");
    }
}
