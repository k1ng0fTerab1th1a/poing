using Domain.Player;

namespace Domain.Tournament;

public record TournamentId(int Value);

public class Tournament
{
    private Tournament(TournamentName name, MatchWinRule matchWinRule, TournamentFormat format, PlayerId creatorId)
    {
        Name = name;
        MatchWinRule = matchWinRule;
        Format = format;
        CreatedBy = creatorId;
    }

    public TournamentId? Id { get; private set; }
    public TournamentName Name { get; private set; }
    public PlayerId CreatedBy { get; private set; }
    public MatchWinRule MatchWinRule { get; private set; }
    public TournamentFormat Format { get; private set; }

    public void UpdateName(TournamentName name)
    {
        Name = name;
    }

    public void UpdateMatchWinRule(MatchWinRule matchWinRule)
    {
        MatchWinRule = matchWinRule;
    }

    public void UpdateFormat(TournamentFormat format)
    {
        Format = format;
    }

    public static Tournament Create(TournamentName name, MatchWinRule matchWinRule, TournamentFormat format, PlayerId creatorId)
    {
        return new Tournament(name, matchWinRule, format, creatorId);
    }
}

