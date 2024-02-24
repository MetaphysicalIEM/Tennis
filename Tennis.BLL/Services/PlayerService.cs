using Tennis.BLL.IServices;
using Tennis.DTO.DTOs.Player;

namespace Tennis.BLL.Services;
public class PlayerService : IPlayerService
{
    public Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto)
    {
        throw new NotImplementedException();
    }

    public Task DeletePlayerAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerDto> GetPlayerAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PlayerDto>> GetPlayersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PlayerDto> UpdatePlayerAsync(UpdatePlayerDto updatePlayerDto)
    {
        throw new NotImplementedException();
    }
}
