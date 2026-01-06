using Domain.Tournament.Exceptions;

namespace Domain.Tournament;

public record TournamentName
{
    private const int MAX_LENGTH = 30;
    private const int MIN_LENGTH = 3;

    private TournamentName(string tournamentName)
    {
        Value = tournamentName;
    }

    public string Value { get; }

    public static TournamentName Create(string raw)
    {
        string name = raw.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw InvalidTournamentNameException.Blank();
        }
        if (name.Length > MAX_LENGTH)
        {
            throw InvalidTournamentNameException.TooLong(name);
        }
        if (name.Length < MIN_LENGTH)
        {
            throw InvalidTournamentNameException.TooShort(name);
        }

        return new TournamentName(name);
    }
}
