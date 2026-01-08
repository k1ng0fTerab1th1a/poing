using Domain.Player;
using Domain.Tournament.Exceptions;

namespace Domain.Tournament;

public record TournamentId(int Value);

public class Tournament
{
    private readonly IList<PlayerId> _participants = [];

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
    public IReadOnlyCollection<PlayerId> Participants => _participants.AsReadOnly();

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

    public void AddParticipant(PlayerId participant)
    {
        if (_participants.Contains(participant))
        {
            throw TournamentParticipantsException.AlreadyExists();
        }

        _participants.Add(participant);
    }

    public static Tournament Create(TournamentName name, MatchWinRule matchWinRule, TournamentFormat format, PlayerId creatorId)
    {
        return new Tournament(name, matchWinRule, format, creatorId);
    }
}

