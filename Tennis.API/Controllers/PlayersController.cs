using Microsoft.AspNetCore.Mvc;
using Tennis.DTO.DTOs.Player;

namespace Tennis.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
    {
        return [];
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDto>> GetPlayerAsync(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<PlayerDto>> CreatePlayerAsync([FromBody] CreatePlayerDto createPlayerDto)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlayerDto>> UpdatePlayerAsync(int id, [FromBody] UpdatePlayerDto updatePlayerDto)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlayerDto>> DeletePlayerAsync(int id)
    {
        return Ok();
    }
}