using Domain.Player;
using Domain.Tournament.Exceptions;
using Domain.Tournament.Format;

namespace Domain.Tournament;

public record TournamentId(int Value);

public class Tournament
{
    private const int MIN_PARTICIPANTS = 4;
    private enum State
    {
        Planning,
        InProgress,
        Finished
    }

    private State _state;

    private readonly IList<PlayerId> _participants = [];

    private Tournament(TournamentName name, MatchWinRule matchWinRule, TournamentFormat format, PlayerId createdBy, State state)
    {
        Name = name;
        MatchWinRule = matchWinRule;
        Format = format;
        CreatedBy = createdBy;
        _state = state;
    }

    public TournamentId? Id { get; private set; }
    public TournamentName Name { get; private set; }
    public PlayerId CreatedBy { get; private set; }
    public MatchWinRule MatchWinRule { get; private set; }
    public TournamentFormat Format { get; private set; }
    public string StateName => _state switch
    {
        State.Planning => "Planning",
        State.InProgress => "InProgress",
        State.Finished => "Finished",
        _ => throw new InvalidOperationException()
    };
    public IReadOnlyList<PlayerId> Participants => _participants.AsReadOnly();

    public IList<PlannedMatch> Start()
    {
        if (_state != State.Planning)
        {
            throw TournamentException.AlreadyStarted();
        }

        if (Participants.Count < MIN_PARTICIPANTS)
        {
            throw TournamentException.NotEnoughParticipants(Participants.Count, MIN_PARTICIPANTS);
        }

        _state = State.InProgress;
        return Format.GenerateMatches(this);
    }

    public void UpdateName(TournamentName name)
    {
        Name = name;
    }

    public void UpdateMatchWinRule(MatchWinRule matchWinRule)
    {
        if (_state != State.Planning)
        {
            throw TournamentException.AlreadyStarted();
        }

        MatchWinRule = matchWinRule;
    }

    public void UpdateFormat(TournamentFormat format)
    {
        if (_state != State.Planning)
        {
            throw TournamentException.AlreadyStarted();
        }

        Format = format;
    }

    public void AddParticipant(PlayerId participant)
    {
        if (_state != State.Planning)
        {
            throw TournamentException.AlreadyStarted();
        }

        if (_participants.Contains(participant))
        {
            throw TournamentParticipantsException.AlreadyExists();
        }

        _participants.Add(participant);
    }

    public void RemoveParticipant(PlayerId participant)
    {
        if (_state != State.Planning)
        {
            throw TournamentException.AlreadyStarted();
        }

        if (!_participants.Contains(participant))
        {
            throw TournamentParticipantsException.ParticipantNotFound();
        }

        _participants.Remove(participant);
    }

    public static Tournament Create(TournamentName name, MatchWinRule matchWinRule, TournamentFormat format, PlayerId creatorId)
    {
        return new Tournament(name, matchWinRule, format, creatorId, State.Planning);
    }
}

