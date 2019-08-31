using Fantasy.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Data
{
    public class FantasyDbContext : IdentityDbContext<FantasyUser, IdentityRole, string>
    {
        public FantasyDbContext(DbContextOptions<FantasyDbContext> options)
            : base(options)
        {
        }

        public DbSet<FootballPlayer> FootballPlayers { get; set; }
        public DbSet<FootballPlayerInfo> FootballPlayerInfos { get; set; }
        public DbSet<FootballPlayerPosition> FootballPlayerPositions { get; set; }
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Gameweek> Gameweeks { get; set; }
        public DbSet<FantasyPlayer> FantasyPlayers { get; set; }
        public DbSet<GameweekPoints> GameweeksPoints { get; set; }
        public DbSet<GameweekStatus> GameweeksStatuses { get; set; }
        public DbSet<GameweekScore> GameweeksScores { get; set; }
        public DbSet<GameweekStatistics> GameweekStatistics { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<FootballClub>()
                .HasIndex(fc => fc.Tag)
                .IsUnique();

            builder
                .Entity<FootballPlayer>()
                .HasOne(fp => fp.Info)
                .WithOne(fpi => fpi.FootballPlayer)
                .HasForeignKey<FootballPlayerInfo>(fpi => fpi.FootballPlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<GameweekStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.GameweekStatistics)
                        .HasForeignKey(e => e.GameweekId);
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.GameweekStatistics)
                        .HasForeignKey(e => e.PlayerId);
                });

            builder
                .Entity<GameweekStatus>(entity =>
                {
                    entity
                        .HasKey(e => new { e.FantasyPlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.GameweekStatuses)
                        .HasForeignKey(e => e.GameweekId);
                    entity
                        .HasOne(e => e.FantasyPlayer)
                        .WithMany(e => e.GameweekStatuses)
                        .HasForeignKey(e => e.FantasyPlayerId);
                });

            builder
                .Entity<GameweekPoints>(entity =>
                {
                    entity
                        .HasKey(e => new { e.FootbalPlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.GameweekPoints)
                        .HasForeignKey(e => e.GameweekId);
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.GameweekPoints)
                        .HasForeignKey(e => e.FootbalPlayerId);
                });

            builder
                .Entity<GameweekScore>(entity =>
                {
                    entity
                        .HasKey(e => new { UserId = e.FantasyUserId, e.GameweekId });
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.GameweekScoreses)
                        .HasForeignKey(e => e.GameweekId);
                    entity
                        .HasOne(e => e.FantasyUser)
                        .WithMany(e => e.GameweekScoreses)
                        .HasForeignKey(e => e.FantasyUserId);
                });


            builder
                .Entity<Fixture>(entity =>
                {
                    entity
                        .HasOne(e => e.HomeTeam)
                        .WithMany(e => e.HomeGames)
                        .HasForeignKey(e => e.HomeTeamId)
                        .OnDelete(DeleteBehavior.Restrict);
                    entity
                        .HasOne(e => e.AwayTeam)
                        .WithMany(e => e.AwayGames)
                        .HasForeignKey(e => e.AwayTeamId)
                        .HasForeignKey(e => e.AwayTeamId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
