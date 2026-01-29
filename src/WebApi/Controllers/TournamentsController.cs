using Application.TournamentService;
using Application.TournamentService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TournamentsController(TournamentService service, ILogger<TournamentsController> logger) : ControllerBase
{
    private readonly TournamentService _service = service;
    private readonly ILogger<TournamentsController> _logger = logger;

    [HttpGet("{id}", Name = "GetTournamentById")]
    public async Task<ActionResult<TournamentResponse>> Get(int id)
    {
        TournamentResponse? tournamentResponse = await _service.GetByIdAsync(id);

        if (tournamentResponse == null)
        {
            return NotFound();
        }

        return Ok(tournamentResponse);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateTournamentRequest createTournamentRequest)
    {
        _logger.LogInformation("request received: {name}, {matchwinrule}, {format}",
            createTournamentRequest.Name,
            createTournamentRequest.MatchWinRule,
            createTournamentRequest.Format);

        int id = await _service.CreateAsync(createTournamentRequest, 1);

        return CreatedAtAction(nameof(Get), new { id }, null);
    }
}
