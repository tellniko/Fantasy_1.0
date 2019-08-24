using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.FootballPlayers;
using Fantasy.Data.Models.Game;
using Fantasy.Data.Models.Statistics;
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
        public DbSet<GoalkeepingStatistics> GoalkeepingStatistics { get; set; }
        public DbSet<DefenceStatistics> DefenceStatistics { get; set; }
        public DbSet<TeamPlayStatistics> TeamPlayStatistics { get; set; }
        public DbSet<AttackStatistics> AttackStatistics { get; set; }
        public DbSet<DisciplineStatistics> DisciplineStatistics { get; set; }
        public DbSet<MatchStatistics> MatchStatistics { get; set; }
        public DbSet<FantasyPlayer> FantasyPlayers { get; set; }
       // public DbSet<FantasyPlayerStatus> Statuses { get; set; }
        public DbSet<GameweekStatus> GameweeksStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<FootballPlayer>()
                .HasOne(fp => fp.Info)
                .WithOne(fpi => fpi.FootballPlayer)
                .HasForeignKey<FootballPlayerInfo>(fpi => fpi.FootballPlayerId)
                .OnDelete(DeleteBehavior.Cascade);

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
                .Entity<MatchStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.MatchStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.MatchStatistics)
                        .HasForeignKey(e => e.GameweekId);
                });

            builder
                .Entity<GoalkeepingStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.GoalkeepingStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.GoalkeepingStatistics)
                        .HasForeignKey(e => e.GameweekId);
                });

            builder
                .Entity<DefenceStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.DefenceStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.DefenceStatistics)
                        .HasForeignKey(e => e.GameweekId);
                });

            builder
                .Entity<TeamPlayStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.TeamPlayStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.TeamPlayStatistics)
                        .HasForeignKey(e => e.GameweekId);
                });

            builder
                .Entity<AttackStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.AttackStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.AttackStatistics)
                        .HasForeignKey(e => e.GameweekId);
                });

            builder
                .Entity<DisciplineStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.GameweekId });
                    entity
                        .HasOne(e => e.FootballPlayer)
                        .WithMany(e => e.DisciplineStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Gameweek)
                        .WithMany(e => e.DisciplineStatistics)
                        .HasForeignKey(e => e.GameweekId);
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
