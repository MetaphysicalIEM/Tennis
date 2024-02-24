using Microsoft.EntityFrameworkCore;
using Tennis.DAL.DataContext;
using Tennis.DAL.Entities;

namespace Tennis.Test.DbContextTest;
internal static class TennisDbContextTest
{
    public static TennisDbContext GetDbContextTest()
    {
        DbContextOptions<TennisDbContext> options = new DbContextOptionsBuilder<TennisDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;

        PlayerEntity player = new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            ShortName = "J.DO",
            Sex = 0,
            CountryCode = "USA",
            Rank = 1,
            Points = 1000,
            Weight = 75,
            Height = 180,
            Age = 25,
        };

        TennisDbContext context = new(options);
        context.Players.Add(player);
        context.SaveChanges();

        return context;
    }
}