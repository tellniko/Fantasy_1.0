using Fantasy.Data.Models;
using Fantasy.Data.Models.Common;
using Fantasy.Data.Models.Players;
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

        public DbSet<PlayerPersonalInfo> PlayerPersonalInfos { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Gameweek> GameWeeks { get; set; }
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<GoalkeepingStatistics> GoalkeepingStatistics { get; set; }
        public DbSet<DefenceStatistics> DefenceStatistics { get; set; }
        public DbSet<TeamPlayStatistics> TeamPlayStatistics { get; set; }
        public DbSet<AttackStatistics> AttackStatistics { get; set; }
        public DbSet<DisciplineStatistics> DisciplineStatistics { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Season> Seasons { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Player>()
                .HasOne(p => p.PlayerPersonalInfo)
                .WithOne(pi => pi.Player)
                .HasForeignKey<PlayerPersonalInfo>(pi => pi.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<BaseStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.FixtureId });
                    entity
                        .HasOne(e => e.Player)
                        .WithMany(e => e.BaseStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Fixture)
                        .WithMany(e => e.BaseStatistics)
                        .HasForeignKey(e => e.FixtureId);
                });

            builder
                .Entity<GoalkeepingStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.FixtureId });
                    entity
                        .HasOne(e => e.Player)
                        .WithMany(e => e.GoalkeepingStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Fixture)
                        .WithMany(e => e.GoalkeepingStatistics)
                        .HasForeignKey(e => e.FixtureId);
                });

            builder
                .Entity<DefenceStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.FixtureId });
                    entity
                        .HasOne(e => e.Player)
                        .WithMany(e => e.DefenceStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Fixture)
                        .WithMany(e => e.DefenceStatistics)
                        .HasForeignKey(e => e.FixtureId);
                });

            builder
                .Entity<TeamPlayStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.FixtureId });
                    entity
                        .HasOne(e => e.Player)
                        .WithMany(e => e.TeamPlayStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Fixture)
                        .WithMany(e => e.TeamPlayStatistics)
                        .HasForeignKey(e => e.FixtureId);
                });

            builder
                .Entity<AttackStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.FixtureId });
                    entity
                        .HasOne(e => e.Player)
                        .WithMany(e => e.AttackStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Fixture)
                        .WithMany(e => e.AttackStatistics)
                        .HasForeignKey(e => e.FixtureId);
                });

            builder
                .Entity<DisciplineStatistics>(entity =>
                {
                    entity
                        .HasKey(e => new { e.PlayerId, e.FixtureId });
                    entity
                        .HasOne(e => e.Player)
                        .WithMany(e => e.DisciplineStatistics)
                        .HasForeignKey(e => e.PlayerId);
                    entity
                        .HasOne(e => e.Fixture)
                        .WithMany(e => e.DisciplineStatistics)
                        .HasForeignKey(e => e.FixtureId);
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

            //builder
            //    .Entity<PlayerPersonalInfo>(entity =>
            //    {
            //        entity
            //            .HasOne(pi => pi.Country)
            //            .WithMany(c => c.Countries)
            //            .HasForeignKey(pi => pi.CountryId)
            //            .OnDelete(DeleteBehavior.Restrict);
            //        entity
            //            .HasOne(pi => pi.BirthCountry)
            //            .WithMany(c => c.BirthCountries)
            //            .HasForeignKey(pi => pi.BirthCountryId)
            //            .OnDelete(DeleteBehavior.Restrict);
            //    });

               


            base.OnModelCreating(builder);
        }
    }
}
