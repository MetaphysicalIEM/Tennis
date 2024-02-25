using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Tennis.BLL.IServices;
using Tennis.DAL.DataContext;
using Tennis.DAL.Entities;
using Tennis.DTO.DTOs.Country;
using Tennis.DTO.DTOs.Players;
using Tennis.DTO.DTOs.PlayersData;
using Tennis.DTO.Helper;

namespace Tennis.BLL.Services;

public class PlayerService(TennisDbContext context) : IPlayerService
{
    private readonly TennisDbContext _context = context;

    private struct CountryRatio
    {
        public string CountryTag { get; set; }
        public double RatioWinLose { get; set; }
    }

    public async Task<PlayerDto> CreatePlayerAsync(CreatePlayerDto createPlayerDto)
    {
        PlayerEntity player = new()
        {
            FirstName = createPlayerDto.FirstName,
            LastName = createPlayerDto.LastName,
            ShortName = createPlayerDto.ShortName,
            Sex = (int)createPlayerDto.Sex,
            CountryCode = createPlayerDto.CountryCode,
            Rank = createPlayerDto.Data.Rank,
            Points = createPlayerDto.Data.Points,
            Weight = createPlayerDto.Data.Weight,
            Height = createPlayerDto.Data.Height,
            Age = createPlayerDto.Data.Age,
            VictoryNumber = createPlayerDto.VictoryNumber,
            DefeatNumber = createPlayerDto.DefeatNumber,
            CreatedDate = DateTime.UtcNow,
            LastUpdatedDate = DateTime.UtcNow
        };

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return new PlayerDto
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            ShortName = player.ShortName,
            Sex = GetGender(ConvertGenderIntoEnum(player.Sex)),
            Country = new CountryDto
            {
                Picture = $"https://flagsapi.com/{player.CountryCode}/flat/64.png",
                Code = player.CountryCode,
            },
            Data = new PlayerDataDto
            {
                Rank = player.Rank,
                Points = player.Points,
                Weight = player.Weight,
                Height = player.Height,
                Age = player.Age,
                Last = new int[] { 0, 0, 0, 0, 0 }
            },
        };
    }

    public async Task<PlayerDto> UpdatePlayerAsync(int id, UpdatePlayerDto updatePlayerDto)
    {
        PlayerEntity player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

        if (player is null)
        {
            throw new ArgumentNullException(nameof(player), "Failed to find user");
        }

        player.FirstName = updatePlayerDto.FirstName;
        player.LastName = updatePlayerDto.LastName;
        player.ShortName = updatePlayerDto.ShortName;
        player.Sex = (int)updatePlayerDto.Sex;
        player.CountryCode = updatePlayerDto.CountryCode;

        player.Rank = updatePlayerDto.Data.Rank;
        player.Points = updatePlayerDto.Data.Points;
        player.Weight = updatePlayerDto.Data.Weight;
        player.Height = updatePlayerDto.Data.Height;
        player.Age = updatePlayerDto.Data.Age;

        player.VictoryNumber = updatePlayerDto.VictoryNumber;
        player.DefeatNumber = updatePlayerDto.DefeatNumber;

        player.LastUpdatedDate = DateTime.UtcNow;

        _context.Players.Update(player);
        await _context.SaveChangesAsync();

        return new PlayerDto
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            ShortName = player.ShortName,
            Sex = GetGender(ConvertGenderIntoEnum(player.Sex)),
            Country = new CountryDto
            {
                Picture = $"https://flagsapi.com/{player.CountryCode}/flat/64.png",
                Code = player.CountryCode,
            },
            Data = new PlayerDataDto
            {
                Rank = player.Rank,
                Points = player.Points,
                Weight = player.Weight,
                Height = player.Height,
                Age = player.Age,
                Last = new int[] { 0, 0, 0, 0, 0 }
            },
        };
    }



    public async Task DeletePlayerAsync(int id)
    {
        PlayerEntity player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

        if (player is null)
        {
            throw new ArgumentNullException(nameof(player), "Failed to find user");
        }

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
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
            Sex = GetGender(ConvertGenderIntoEnum(player.Sex)),
            Country = new CountryDto
            {
                Picture = $"https://flagsapi.com/{player.CountryCode}/ flat/64.png",
                Code = player.CountryCode,
            },
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
                Sex = GetGender(ConvertGenderIntoEnum(x.Sex)),
                Country = new CountryDto
                {
                    Picture = $"https://flagsapi.com/{x.CountryCode}/flat/64.png",
                    Code = x.CountryCode,
                },
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
        return new PlayersDataStatisticsDto
        {
            CountryWithHighestWinRatio = await GetCountryWithHighestWinRatio(),
            AverageBMI = await GetAverageBMI(),
            MedianPlayerHeight = await GetMedianPlayerHeight()
        };
    }

    private async Task<string> GetCountryWithHighestWinRatio()
    {
        var list = await _context.Players.GroupBy(u => u.CountryCode).ToListAsync();
        List<CountryRatio> countryRatios = new();

        foreach (var item in list)
        {
            int totalVictories = item.Sum(u => u.VictoryNumber);
            int totalDefeats = item.Sum(u => u.DefeatNumber);
            double ratio = (totalVictories * 100.0) / (totalVictories + totalDefeats);

            countryRatios.Add(new CountryRatio { CountryTag = item.Key, RatioWinLose = ratio });
        }

        return countryRatios.OrderBy(u => u.RatioWinLose).First().CountryTag;
    }

    private async Task<double> GetAverageBMI() => await _context.Players.AverageAsync(p => p.Weight / Math.Pow(p.Height / 100, 2));

    private async Task<int> GetMedianPlayerHeight()
    {
        PlayerEntity[] players = await _context.Players.OrderBy(p => p.Height).ToArrayAsync();
        int medianPlayerHeight = 0;
        int count = players.Length;
        int middleIndex = count / 2;

        if (count % 2 != 0)
        {
            medianPlayerHeight = players[middleIndex].Weight;
        }
        else
        {
            medianPlayerHeight = (players[middleIndex - 1].Weight + players[middleIndex].Weight) / 2;
        }

        return medianPlayerHeight;
    }

    private static string GetGender(Gender gender)
    {
        return gender switch
        {
            Gender.MALE => "M",
            Gender.FEMALE => "F",
            Gender.OTHER => "O",
            _ => "X",
        };
    }

    private static Gender ConvertGenderIntoEnum(int sex)
    {
        if (Enum.IsDefined(typeof(Gender), sex))
        {
            return (Gender)sex;
        }
        else
        {
            return Gender.UNKNOW;
        }
    }
}
