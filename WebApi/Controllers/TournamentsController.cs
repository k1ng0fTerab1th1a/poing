using Application.TournamentService;
using Application.TournamentService.DTOs;
using Domain.Player;
using Domain.Tournament;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentsController(TournamentService service, ILogger<TournamentsController> logger) : ControllerBase
{
    private readonly TournamentService _service = service;
    private readonly ILogger<TournamentsController> _logger = logger;

    [HttpGet("{id}", Name = "GetTournamentById")]
    public Task Get(TournamentId id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTournamentRequest createTournamentRequest)
    {
        _logger.LogInformation("request received: {name}, {matchwinrule}, {format}", 
            createTournamentRequest.TournamentName, 
            createTournamentRequest.MatchWinRule, 
            createTournamentRequest.Format);

        TournamentId id = await _service.Create(createTournamentRequest, new PlayerId(1));

        return CreatedAtRoute("GetTournamentById", id);
    }
}
