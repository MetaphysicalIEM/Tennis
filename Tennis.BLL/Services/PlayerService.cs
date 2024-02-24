using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tennis.BLL.IServices;
using Tennis.DAL.DataContext;
using Tennis.DAL.Entities;
using Tennis.DTO.DTOs.Players;
using Tennis.DTO.DTOs.PlayersData;
using Tennis.DTO.Helper;

namespace Tennis.BLL.Services;
public class PlayerService(TennisDbContext context) : IPlayerService
{
    private readonly TennisDbContext _context = context;

    public async Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePlayerAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PlayerDto> GetPlayerAsync(int id)
    {
        PlayerEntity player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

        if (player is null)
        {
            throw new ArgumentNullException(nameof(player), "Failed to find user");
        }

        return new PlayerDto
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            ShortName = player.ShortName,
            Sex = ((Gender)player.Sex).ToString(),
            CountryCode = player.CountryCode,
            Picture = "none",
            Data = new PlayerDataDto
            {
                Rank = player.Rank,
                Points = player.Points,
                Weight = player.Weight,
                Height = player.Height,
                Age = player.Age,
                Last = new int[] { 0, 0, 0, 0, 0 }
            }
        };
    }

    public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
    {
        return await _context.Players
            .OrderBy(x => x.Rank)
            .Select(x => new PlayerDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ShortName = x.ShortName,
                Sex = ((Gender)x.Sex).ToString(),
                CountryCode = x.CountryCode,
                Picture = "none",
                Data = new PlayerDataDto
                {
                    Rank = x.Rank,
                    Points = x.Points,
                    Weight = x.Weight,
                    Height = x.Height,
                    Age = x.Age,
                    Last = new int[] { 0, 0, 0, 0, 0 }
                }
            })
            .ToListAsync();
    }

    public async Task<PlayersDataStatisticsDto> GetPlayersDataStatisticsAsync()
    {
        PlayerEntity[] players = await _context.Players.OrderBy(p => p.Height).ToArrayAsync();
        double averageBMI = await _context.Players.AverageAsync(p => p.Weight / Math.Pow(p.Height / 100, 2));
        int medianPlayerHeight = 0;
        int count = players.Length;
        int middleIndex = count / 2;
        string countryWithHighestWinRatio = "USA";

        if (count % 2 != 0)
        {
            medianPlayerHeight = players[middleIndex].Weight;
        }
        else
        {
            medianPlayerHeight = (players[middleIndex - 1].Weight + players[middleIndex].Weight) / 2;
        }

        return new PlayersDataStatisticsDto
        {
            CountryWithHighestWinRatio = countryWithHighestWinRatio,
            AverageBMI = averageBMI,
            MedianPlayerHeight = medianPlayerHeight
        };
    }

    public async Task<PlayerDto> UpdatePlayerAsync(UpdatePlayerDto updatePlayerDto)
    {
        throw new NotImplementedException();
    }
}
