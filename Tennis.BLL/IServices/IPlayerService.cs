using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.DTO.DTOs.Player;

namespace Tennis.BLL.IServices;
public interface IPlayerService
{
    Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto);
    Task<PlayerDto> UpdatePlayerAsync(UpdatePlayerDto updatePlayerDto);
    Task<PlayerDto> GetPlayerAsync(int id);
    Task<IEnumerable<PlayerDto>> GetPlayersAsync();
    Task DeletePlayerAsync(int id);
}