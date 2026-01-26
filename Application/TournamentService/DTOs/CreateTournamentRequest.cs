namespace Application.TournamentService.DTOs;

public class CreateTournamentRequest
{
    public required string Name { get; set; }
    public required string MatchWinRule { get; set; }
    public required string Format { get; set; }
}
