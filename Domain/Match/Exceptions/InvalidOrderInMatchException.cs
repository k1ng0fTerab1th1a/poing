using Domain.Shared;

namespace Domain.Match.Exceptions;

public class InvalidOrderInMatchException : DomainException
{
    private InvalidOrderInMatchException(string message) : base(message) { }

    internal static InvalidOrderInMatchException Negative(int orderInMatch)
    {
        return new InvalidOrderInMatchException($"{orderInMatch} is not a valid order for a game:" +
            $" it must be non-negative.");
    }

    internal static InvalidOrderInMatchException CannotChange(int orderInMatchOld, int orderInMatchNew)
    {
        return new InvalidOrderInMatchException($"Cannot change order for a game from {orderInMatchOld} to {orderInMatchNew}");
    }
}
