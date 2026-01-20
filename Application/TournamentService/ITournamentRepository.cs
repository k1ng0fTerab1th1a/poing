using Domain.Tournament;

namespace Application.TournamentService;

public interface ITournamentRepository
{
    public Task AddAsync(Tournament tournament);
    public Task<Tournament?> GetByIdAsync(TournamentId tournamentId);
    public Task RemoveAsync(TournamentId tournamentId);
}
