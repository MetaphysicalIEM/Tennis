using Tennis.DTO.DTOs.Players;
using Tennis.DTO.DTOs.PlayersData;

namespace Tennis.BLL.IServices;
public interface IPlayerService
{
    Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto);
    Task<PlayerDto> UpdatePlayerAsync(UpdatePlayerDto updatePlayerDto);
    Task<PlayerDto> GetPlayerAsync(int id);
    Task<IEnumerable<PlayerDto>> GetPlayersAsync();
    Task DeletePlayerAsync(int id);
    Task<PlayersDataStatisticsDto> GetPlayersDataStatisticsAsync();
}