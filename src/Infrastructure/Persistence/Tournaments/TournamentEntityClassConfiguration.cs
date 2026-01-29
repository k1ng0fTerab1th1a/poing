using Domain.Player;
using Domain.Tournament;
using Domain.Tournament.Format;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Tournaments;

internal class TournamentEntityClassConfiguration : IEntityTypeConfiguration<Tournament>
{
    public void Configure(EntityTypeBuilder<Tournament> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.Id).HasConversion(
                id => id!.Value,
                value => new TournamentId(value));
        builder.Property(t => t.Name).HasConversion(
                name => name.Value,
                value => TournamentName.Create(value));
        builder.Property(t => t.CreatedBy).HasConversion(
                createdBy => createdBy.Value,
                value => new PlayerId(value));
        builder.Property(t => t.MatchWinRule).HasConversion(
                matchWinRule => matchWinRule.Value,
                value => MatchWinRule.FromValue(value)!);
        builder.Property(t => t.Format).HasConversion(
                format => format.Value,
                value => TournamentFormat.FromValue(value)!);

        builder.Property("_state").HasColumnName("State");

        builder.Property(t => t.Name).HasMaxLength(50);
    }
}
