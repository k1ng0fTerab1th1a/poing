using Application.Shared;
using Domain.Player;
using Domain.Tournament;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class PoingDbContext : DbContext, IUnitOfWork
{
    public DbSet<Tournament> Tournaments { get; set; }

    public PoingDbContext(DbContextOptions<PoingDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<PlayerId>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PoingDbContext).Assembly);
    }

    public async Task CommitAsync()
    {
        int n = await SaveChangesAsync();
        Console.WriteLine("database changes: " + n);
    }
}
