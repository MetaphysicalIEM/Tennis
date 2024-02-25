using Microsoft.AspNetCore.Mvc;
using Tennis.BLL.IServices;
using Tennis.DTO.DTOs.Players;
using Tennis.DTO.DTOs.PlayersData;

namespace Tennis.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlayersController(IPlayerService playerService) : ControllerBase
{
    private readonly IPlayerService _playerService = playerService;

    [HttpGet("statistics")]
    public async Task<ActionResult<PlayersDataStatisticsDto>> GetPlayersDataStatisticsAsync()
    {
        PlayersDataStatisticsDto playersDataStatisticsDto = await _playerService.GetPlayersDataStatisticsAsync();
        return Ok(playersDataStatisticsDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayersAsync()
    {
        IEnumerable<PlayerDto> playerDtos = await _playerService.GetPlayersAsync();
        return Ok(playerDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDto>> GetPlayerAsync(int id)
    {
        try
        {
            PlayerDto playerDto = await _playerService.GetPlayerAsync(id);
            return Ok(playerDto);
        }
        catch (ArgumentNullException)
        {
            return BadRequest("User not found");
        }
        catch
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult<PlayerDto>> CreatePlayerAsync([FromBody] CreatePlayerDto createPlayerDto)
    {
        PlayerDto playerDto = await _playerService.CreatePlayerAsync(createPlayerDto);
        return Ok(playerDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PlayerDto>> UpdatePlayerAsync(int id, [FromBody] UpdatePlayerDto updatePlayerDto)
    {
        try
        {
            PlayerDto updatedPlayer = await _playerService.UpdatePlayerAsync(id, updatePlayerDto);
            return Ok(updatedPlayer);
        }
        catch (ArgumentNullException)
        {
            return BadRequest($"Failed to update player");
        }
        catch
        {
            throw;
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<PlayerDto>> DeletePlayerAsync(int id)
    {
        try
        {
            await _playerService.DeletePlayerAsync(id);
            return Ok();
        }
        catch (ArgumentNullException)
        {
            return BadRequest($"Failed to delete player");
        }
        catch
        {
            throw;
        }
    }
}