﻿// <auto-generated />
using System;
using Fantasy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fantasy.Data.Migrations
{
    [DbContext(typeof(FantasyDbContext))]
    [Migration("20190816195800_shortByteAgain")]
    partial class shortByteAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fantasy.Data.Models.Common.FantasyUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<decimal>("Budget");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("Rating");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("FootballClubs");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.FootballClubInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BadgeUrl");

                    b.Property<int>("FootballClubId");

                    b.Property<string>("Ground");

                    b.Property<string>("ManagerName");

                    b.Property<bool>("Playable");

                    b.Property<string>("PrimaryKitColor");

                    b.Property<string>("SecondaryKitColor");

                    b.Property<string>("StadiumImgUrl");

                    b.HasKey("Id");

                    b.HasIndex("FootballClubId")
                        .IsUnique();

                    b.ToTable("FootballClubInfos");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Gameweek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Finished");

                    b.Property<byte>("Number");

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

            modelBuilder.Entity("Fantasy.Data.Models.FootballPlayers.FootballPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FootballClubId");

                    b.Property<int>("FootballPlayerPositionId");

                    b.Property<bool>("IsInjured");

                    b.Property<bool>("IsPlayable");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FootballClubId");

                    b.HasIndex("FootballPlayerPositionId");

                    b.ToTable("FootballPlayers");
                });

            modelBuilder.Entity("Fantasy.Data.Models.FootballPlayers.FootballPlayerInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BigImgUrl")
                        .IsRequired();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("BirthPlace")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .HasMaxLength(50);

                    b.Property<int>("FootballPlayerId");

                    b.Property<byte>("Height");

                    b.Property<DateTime?>("JoinDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte>("ShirtNumber");

                    b.Property<string>("SmallImgUrl");

                    b.Property<byte>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("FootballPlayerId")
                        .IsUnique();

                    b.ToTable("FootballPlayerInfos");
                });

            modelBuilder.Entity("Fantasy.Data.Models.FootballPlayers.FootballPlayerPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("FootballPlayerPositions");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Game.FantasyUserPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FantasyUserSquadId");

                    b.Property<int>("FootballPlayerId");

                    b.Property<bool>("IsFirstTeam");

                    b.HasKey("Id");

                    b.HasIndex("FantasyUserSquadId");

                    b.HasIndex("FootballPlayerId");

                    b.ToTable("FantasyUserPlayers");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Game.FantasyUserSquad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameweekId");

                    b.Property<short>("Transfers");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GameweekId");

                    b.HasIndex("UserId");

                    b.ToTable("FantasyUserSquad");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.AttackStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameweekId");

                    b.Property<short>("BigChancesMissed");

                    b.Property<short>("FreeKicksScored");

                    b.Property<short>("Goals");

                    b.Property<short>("HitWoodwork");

                    b.Property<short>("PenaltiesScored");

                    b.Property<short>("Shots");

                    b.Property<short>("ShotsOnTarget");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("GameweekId");

                    b.ToTable("AttackStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DefenceStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameweekId");

                    b.Property<short>("AerialBattlesLost");

                    b.Property<short>("AerialBattlesWon");

                    b.Property<short>("BlockedShots");

                    b.Property<short>("CleanSheets");

                    b.Property<short>("Clearances");

                    b.Property<short>("DuelsLost");

                    b.Property<short>("DuelsWon");

                    b.Property<short>("ErrorsLeadingToGoal");

                    b.Property<short>("GoalsConceded");

                    b.Property<short>("HeadedClearance");

                    b.Property<short>("Interceptions");

                    b.Property<short>("LastManTackles");

                    b.Property<short>("OwnGoals");

                    b.Property<short>("Recoveries");

                    b.Property<short>("SuccessfulFiftyFifties");

                    b.Property<short>("Tackles");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("GameweekId");

                    b.ToTable("DefenceStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DisciplineStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameweekId");

                    b.Property<short>("Fouls");

                    b.Property<short>("Offsides");

                    b.Property<short>("RedCards");

                    b.Property<short>("YellowCards");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("GameweekId");

                    b.ToTable("DisciplineStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.GoalkeepingStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameweekId");

                    b.Property<short>("Catches");

                    b.Property<short>("GoalKicks");

                    b.Property<short>("HighClaims");

                    b.Property<short>("PenaltiesSaved");

                    b.Property<short>("Punches");

                    b.Property<short>("Saves");

                    b.Property<short>("SweeperClearances");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("GameweekId");

                    b.ToTable("GoalkeepingStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.MatchStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameweekId");

                    b.Property<short>("Appearances");

                    b.Property<int?>("FootballPlayerId");

                    b.Property<short>("Losses");

                    b.Property<short>("Wins");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("FootballPlayerId");

                    b.HasIndex("GameweekId");

                    b.ToTable("MatchStatistics");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.TeamPlayStatistics", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameweekId");

                    b.Property<short>("AccurateLongBalls");

                    b.Property<short>("Assists");

                    b.Property<short>("BigChancesCreated");

                    b.Property<short>("Crosses");

                    b.Property<short>("Passes");

                    b.Property<short>("ThroughBalls");

                    b.HasKey("PlayerId", "GameweekId");

                    b.HasIndex("GameweekId");

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

            modelBuilder.Entity("Fantasy.Data.Models.Common.FootballClubInfo", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FootballClub", "FootballClub")
                        .WithOne("Info")
                        .HasForeignKey("Fantasy.Data.Models.Common.FootballClubInfo", "FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Common.Gameweek", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Season", "Season")
                        .WithMany("Gameweeks")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.FootballPlayers.FootballPlayer", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.FootballClub", "FootballClub")
                        .WithMany("Squad")
                        .HasForeignKey("FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayerPosition", "FootballPlayerPosition")
                        .WithMany("FootballPlayers")
                        .HasForeignKey("FootballPlayerPositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.FootballPlayers.FootballPlayerInfo", b =>
                {
                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithOne("Info")
                        .HasForeignKey("Fantasy.Data.Models.FootballPlayers.FootballPlayerInfo", "FootballPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Game.FantasyUserPlayer", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Game.FantasyUserSquad")
                        .WithMany("Squad")
                        .HasForeignKey("FantasyUserSquadId");

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithMany("FantasyUserPlayers")
                        .HasForeignKey("FootballPlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Game.FantasyUserSquad", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany()
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.Common.FantasyUser", "User")
                        .WithMany("Squads")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.AttackStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("AttackStatistics")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithMany("AttackStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DefenceStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("DefenceStatistics")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithMany("DefenceStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.DisciplineStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("DisciplineStatistics")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithMany("DisciplineStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.GoalkeepingStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("GoalkeepingStatistics")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithMany("GoalkeepingStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.MatchStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer")
                        .WithMany("MatchStatistics")
                        .HasForeignKey("FootballPlayerId");

                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("BaseStatistics")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
                        .WithMany("BaseStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fantasy.Data.Models.Statistics.TeamPlayStatistics", b =>
                {
                    b.HasOne("Fantasy.Data.Models.Common.Gameweek", "Gameweek")
                        .WithMany("TeamPlayStatistics")
                        .HasForeignKey("GameweekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fantasy.Data.Models.FootballPlayers.FootballPlayer", "FootballPlayer")
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
