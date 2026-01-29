using Domain.Player;
using Domain.Tournament;

namespace Application.TournamentService.DTOs;

public class TournamentResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required int CreatedBy { get; set; }
    public required string MatchWinRule { get; set; }
    public required string Format { get; set; }
    public required string State { get; set; }
    public required IEnumerable<int> Participants { get; set; }
}
