using Application.Shared;
using Application.TournamentService.DTOs;
using Domain.Player;
using Domain.Tournament;
using Domain.Tournament.Format;

namespace Application.TournamentService;

public class TournamentService(ITournamentRepository repository, IUnitOfWork unitOfWork)
{
    private readonly ITournamentRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> CreateAsync(CreateTournamentRequest createTournamentRequest, int createdByPlayerId)
    {
        MatchWinRule matchWinRule = MatchWinRule.FromName(createTournamentRequest.MatchWinRule) 
            ?? throw ValidationException.InvalidValue(nameof(createTournamentRequest.MatchWinRule), createTournamentRequest.MatchWinRule);

        TournamentFormat tournamentFormat = TournamentFormat.FromName(createTournamentRequest.Format) 
            ?? throw ValidationException.InvalidValue(nameof(createTournamentRequest.Format), createTournamentRequest.Format);

        Tournament tournament = Tournament.Create(
            TournamentName.Create(createTournamentRequest.Name),
            matchWinRule,
            tournamentFormat,
            new PlayerId(createdByPlayerId)
        );

        _repository.Add(tournament);
        await _unitOfWork.CommitAsync();

        return tournament.Id!.Value;
    }

    public async Task<TournamentResponse?> GetByIdAsync(int id)
    {
        Tournament? tournament = await _repository.GetByIdAsync(new TournamentId(id));

        if (tournament == null)
        {
            return null;
        }

        return new TournamentResponse
        {
            Id = tournament.Id!.Value,
            Name = tournament.Name.Value,
            CreatedBy = tournament.CreatedBy.Value,
            MatchWinRule = tournament.MatchWinRule.Name,
            Format = tournament.Format.Name,
            State = tournament.StateName,
            Participants = tournament.Participants.Select(playerId => playerId.Value),
        };
    }
}
