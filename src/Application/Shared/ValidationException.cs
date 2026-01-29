namespace Application.Shared;

public class ValidationException : Exception
{
    private ValidationException(string message) : base(message) { }

    internal static ValidationException InvalidValue(string propertyName, string givenValue)
    {
        return new ValidationException($"Value \"{givenValue}\" given for property {propertyName} is invalid.");
    }
}
