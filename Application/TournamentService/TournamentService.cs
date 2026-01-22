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

    public async Task<TournamentId> Create(CreateTournamentRequest createTournamentRequest, PlayerId createdBy)
    {
        MatchWinRule matchWinRule = MatchWinRule.FromName(createTournamentRequest.MatchWinRule) 
            ?? throw ValidationException.InvalidValue(nameof(createTournamentRequest.MatchWinRule), createTournamentRequest.MatchWinRule);

        TournamentFormat tournamentFormat = TournamentFormat.FromName(createTournamentRequest.Format) 
            ?? throw ValidationException.InvalidValue(nameof(createTournamentRequest.Format), createTournamentRequest.Format);

        Tournament tournament = Tournament.Create(
            TournamentName.Create(createTournamentRequest.TournamentName),
            matchWinRule,
            tournamentFormat,
            createdBy
        );

        await _repository.AddAsync(tournament);
        await _unitOfWork.CommitAsync();

        return tournament.Id!;
    }
}
