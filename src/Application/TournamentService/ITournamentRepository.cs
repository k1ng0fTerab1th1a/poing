using Domain.Tournament;

namespace Application.TournamentService;

public interface ITournamentRepository
{
    public void Add(Tournament tournament);
    public Task<Tournament?> GetByIdAsync(TournamentId tournamentId);
    public void Remove(Tournament tournament);
}
