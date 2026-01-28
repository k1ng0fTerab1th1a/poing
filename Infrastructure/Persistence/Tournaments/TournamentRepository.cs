using Application.TournamentService;
using Domain.Tournament;

namespace Infrastructure.Persistence.Tournaments;

public class TournamentRepository : ITournamentRepository
{
    private readonly PoingDbContext _context;

    public TournamentRepository(PoingDbContext context)
    {
        _context = context;
    }

    public void Add(Tournament tournament)
    {
        _context.Tournaments.Add(tournament);
    }

    public async Task<Tournament?> GetByIdAsync(TournamentId tournamentId)
    {
        return await _context.Tournaments.FindAsync(tournamentId);
    }

    public void Remove(Tournament tournament)
    {
        _context.Tournaments.Remove(tournament);
    }
}
