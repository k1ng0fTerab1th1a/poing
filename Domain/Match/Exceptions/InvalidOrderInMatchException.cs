using Domain.Shared;

namespace Domain.Match.Exceptions;

public class InvalidOrderInMatchException : DomainException
{
    private InvalidOrderInMatchException(string message) : base(message) { }

    internal static InvalidOrderInMatchException NotPositive(int orderInMatch)
    {
        return new InvalidOrderInMatchException($"{orderInMatch} is not a valid order for a game:" +
            $" it must be positive.");
    }

    internal static InvalidOrderInMatchException CannotChange(int orderInMatchOld, int orderInMatchNew)
    {
        return new InvalidOrderInMatchException($"Cannot change order for a game from {orderInMatchOld} to {orderInMatchNew}");
    }
}
