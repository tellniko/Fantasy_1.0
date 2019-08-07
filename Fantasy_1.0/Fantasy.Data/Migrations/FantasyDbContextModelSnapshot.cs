﻿// <auto-generated />
using System;
using Fantasy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fantasy.Data.Migrations
{
    [DbContext(typeof(FantasyDbContext))]
    partial class FantasyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fantasy.Data.Models.Common.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FlagUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.FantasyUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("FootballClubId");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SquadName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("FootballClubId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Fixture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayTeamId");

                    b.Property<DateTime?>("DateTimeStart");

                    b.Property<bool>("Finished");

                    b.Property<int>("GameWeekId");

                    b.Property<int>("HomeTeamId");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("GameWeekId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.FootballClub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ground");

                    b.Property<string>("ManagerName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Playable");

                    b.Property<string>("PrimaryKitColor");

                    b.Property<byte>("Rating");

                    b.Property<string>("SecondaryKitColor");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("StadiumImgUrl");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("FootballClubs");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Gameweek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished");

                    b.Property<int>("Number");

                    b.Property<int>("SeasonId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("GameWeeks");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FootballClubId");

                    b.Property<bool>("IsFirstTeam");

                    b.Property<bool>("IsInjured");

                    b.Property<bool>("IsPlayable");

                    b.Property<int>("LeagueId");

                    b.Property<int>("PositionId");

                    b.HasKey("Id");

                    b.HasIndex("FootballClubId");

                    b.HasIndex("PositionId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Fantasy.Data.Models.PlayerPersonalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirthCountry");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("BirthPlace")
                        .HasMaxLength(50);

                    b.Property<string>("Country");

                    b.Property<int?>("CountryId");

                    b.Property<int?>("CountryId1");

                    b.Property<string>("FootballPlayerImageUrl")
                        .IsRequired();

                    b.Property<byte>("Height");

                    b.Property<DateTime?>("JoinDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PlayerId");

                    b.Property<byte>("ShirtNum");

                    b.Property<byte>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CountryId1");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("PlayerPersonalInfos");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Players.PlayerPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PlayerPositions");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.AttackStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("FixtureId");

                    b.Property<int>("BigChancesMissed");

                    b.Property<int>("FreeKicksScored");

                    b.Property<int>("Goals");

                    b.Property<int>("HitWoodwork");

                    b.Property<int>("PenaltiesScored");

                    b.Property<int>("Shots");

                    b.Property<int>("ShotsOnTarget");

                    b.HasKey("PlayerId", "FixtureId");

                    b.HasIndex("FixtureId");

                    b.ToTable("AttackStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.BaseStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("FixtureId");

                    b.Property<int>("Appearances");

                    b.Property<int>("Losses");

                    b.Property<int>("Wins");

                    b.HasKey("PlayerId", "FixtureId");

                    b.HasIndex("FixtureId");

                    b.ToTable("BaseStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DefenceStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("FixtureId");

                    b.Property<int>("AerialBattlesLost");

                    b.Property<int>("AerialBattlesWon");

                    b.Property<int>("BlockedShots");

                    b.Property<int>("CleanSheets");

                    b.Property<int>("Clearances");

                    b.Property<int>("DuelsLost");

                    b.Property<int>("DuelsWon");

                    b.Property<int>("ErrorsLeadingToGoal");

                    b.Property<int>("GoalsConceded");

                    b.Property<int>("HeadedClearance");

                    b.Property<int>("Interceptions");

                    b.Property<int>("LastManTackles");

                    b.Property<int>("OwnGoals");

                    b.Property<int>("Recoveries");

                    b.Property<int>("SuccessfulFiftyFifties");

                    b.Property<int>("Tackles");

                    b.HasKey("PlayerId", "FixtureId");

                    b.HasIndex("FixtureId");

                    b.ToTable("DefenceStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DisciplineStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("FixtureId");

                    b.Property<int>("Fouls");

                    b.Property<int>("Offsides");

                    b.Property<int>("RedCards");

                    b.Property<int>("YellowCards");

                    b.HasKey("PlayerId", "FixtureId");

                    b.HasIndex("FixtureId");

                    b.ToTable("DisciplineStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.GoalkeepingStatistics", b =>
                {
                    b.Property<int?>("PlayerId");

                    b.Property<int>("FixtureId");

                    b.Property<int>("Catches");

                    b.Property<int>("GoalKicks");

                    b.Property<int>("HighClaims");

                    b.Property<int>("PenaltiesSaved");

                    b.Property<int>("Punches");

                    b.Property<int>("Saves");

                    b.Property<int>("SweeperClearances");

                    b.HasKey("PlayerId", "FixtureId");

                    b.HasIndex("FixtureId");

                    b.ToTable("GoalkeepingStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.TeamPlayStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("FixtureId");

                    b.Property<int>("AccurateLongBalls");

                    b.Property<int>("Assists");

                    b.Property<int>("BigChancesCreated");

                    b.Property<int>("Crosses");

                    b.Property<int>("Passes");

                    b.Property<int>("ThroughBalls");

                    b.HasKey("PlayerId", "FixtureId");

                    b.HasIndex("FixtureId");

                    b.ToTable("TeamPlayStatistics");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.FantasyUser", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FootballClub", "FootballClub")
                        .WithMany()
                        .HasForeignKey("FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Fixture", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FootballClub", "AwayTeam")
                        .WithMany("AwayGames")
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("Fixtures")
                        .HasForeignKey("GameWeekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Common.FootballClub", "HomeTeam")
                        .WithMany("HomeGames")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Gameweek", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Season", "Season")
                        .WithMany("Gameweeks")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Player", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FootballClub", "FootballClub")
                        .WithMany("Squad")
                        .HasForeignKey("FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Players.PlayerPosition", "Position")
                        .WithMany("Players")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.PlayerPersonalInfo", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Country")
                        .WithMany("BirthCountries")
                        .HasForeignKey("CountryId");

                    b.HasOne("Fantasy.Data.Models.Common.Country")
                        .WithMany("Countries")
                        .HasForeignKey("CountryId1");

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithOne("PlayerPersonalInfo")
                        .HasForeignKey("Fantasy.Data.Models.PlayerPersonalInfo", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.AttackStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Fixture", "Fixture")
                        .WithMany("AttackStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithMany("AttackStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.BaseStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Fixture", "Fixture")
                        .WithMany("BaseStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithMany("BaseStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DefenceStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Fixture", "Fixture")
                        .WithMany("DefenceStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithMany("DefenceStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DisciplineStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Fixture", "Fixture")
                        .WithMany("DisciplineStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithMany("DisciplineStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.GoalkeepingStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Fixture", "Fixture")
                        .WithMany("GoalkeepingStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithMany("GoalkeepingStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.TeamPlayStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Fixture", "Fixture")
                        .WithMany("TeamPlayStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Player", "Player")
                        .WithMany("TeamPlayStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FantasyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FantasyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Common.FantasyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FantasyUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
