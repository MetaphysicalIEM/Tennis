using Tennis.BLL.Services;
using Tennis.DAL.DataContext;
using Tennis.DTO.DTOs.Players;
using Tennis.Test.DbContextTest;

namespace Tennis.Test.ServicesTest;
public class PlayerServiceTest
{
    private readonly TennisDbContext _context;

    public PlayerServiceTest()
    {
        _context = TennisDbContextTest.GetDbContextTest();
    }

    [Fact]
    public async Task Test1()
    {
        PlayerService playerService = new(_context);
        PlayerDto user = await playerService.GetPlayerAsync(1);
        Assert.NotNull(user);
    }

    [Fact]
    public async Task TestNotEmpty()
    {
        PlayerService playerService = new(_context);
        IEnumerable<PlayerDto> user = await playerService.GetPlayersAsync();
        Assert.NotEmpty(user);
        Assert.NotNull(user);
        Assert.Single(user);
    }
}