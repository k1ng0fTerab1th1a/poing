using Domain.Player.Exceptions;

namespace Domain.Player;

public record PlayerName
{
    private const int MAX_LENGTH = 30;
    private const int MIN_LENGTH = 3;

    private PlayerName(string playerName)
    {
        Value = playerName;
    }

    public string Value { get; }

    public static PlayerName Create(string raw)
    {
        string name = raw.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw InvalidPlayerNameException.Blank();
        }
        if (name.Length > MAX_LENGTH)
        {
            throw InvalidPlayerNameException.TooLong(name);
        } 
        if (name.Length < MIN_LENGTH)
        {
            throw InvalidPlayerNameException.TooShort(name);
        } 

        return new PlayerName(name);
    }
}
