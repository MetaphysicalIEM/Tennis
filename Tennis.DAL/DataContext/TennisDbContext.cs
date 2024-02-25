using Microsoft.EntityFrameworkCore;
using Tennis.DAL.Entities;

namespace Tennis.DAL.DataContext;
public class TennisDbContext(DbContextOptions<TennisDbContext> options) : DbContext(options)
{
    public DbSet<PlayerEntity> Players { get; set; }
    public DbSet<GameOutcomeEntity> GameOutComes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerEntity>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            x.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            x.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            x.Property(u => u.ShortName).IsRequired().HasMaxLength(50);
            x.Property(u => u.Sex).IsRequired();
            x.Property(u => u.CountryCode).IsRequired().HasMaxLength(3);
            x.Property(u => u.Rank).IsRequired();
            x.Property(u => u.Points).IsRequired();
            x.Property(u => u.Weight).IsRequired();
            x.Property(u => u.Height).IsRequired();
            x.Property(u => u.Age).IsRequired();
            x.Property(u => u.VictoryNumber).IsRequired();
            x.Property(u => u.DefeatNumber).IsRequired();
            x.Property(u => u.CreatedDate).IsRequired().HasColumnType("timestamp without time zone");
            x.Property(u => u.LastUpdatedDate).IsRequired().HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<GameOutcomeEntity>(x =>
        {
            x.HasKey(x => x.Id);
            x.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            x.Property(u => u.IdWinner).IsRequired();
            x.HasOne<PlayerEntity>()
                .WithMany()
                .HasForeignKey(u => u.IdWinner)
                .OnDelete(DeleteBehavior.NoAction);

            x.Property(u => u.IdLoser).IsRequired();
            x.HasOne<PlayerEntity>()
                .WithMany()
                .HasForeignKey(u => u.IdLoser)
                .OnDelete(DeleteBehavior.NoAction);

            x.Property(u => u.DateStartGame).IsRequired().HasColumnType("timestamp without time zone");
            x.Property(u => u.DateEndGame).IsRequired().HasColumnType("timestamp without time zone");
        });
    }
}