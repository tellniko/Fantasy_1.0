using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballClubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(maxLength: 50, nullable: false),
                    Tag = table.Column<string>(maxLength: 3, nullable: false),
                    Rating = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayerPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayerPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    SquadName = table.Column<string>(maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(nullable: false),
                    FootballClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_FootballClubs_FootballClubId",
                        column: x => x.FootballClubId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballClubInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StadiumImgUrl = table.Column<string>(nullable: true),
                    Playable = table.Column<bool>(nullable: false),
                    ManagerName = table.Column<string>(nullable: true),
                    Ground = table.Column<string>(nullable: true),
                    BadgeUrl = table.Column<string>(nullable: true),
                    PrimaryKitColor = table.Column<string>(nullable: true),
                    SecondaryKitColor = table.Column<string>(nullable: true),
                    FootballClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballClubInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballClubInfos_FootballClubs_FootballClubId",
                        column: x => x.FootballClubId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsInjured = table.Column<bool>(nullable: false),
                    IsPlayable = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    FootballPlayerPositionId = table.Column<int>(nullable: false),
                    FootballClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballClubs_FootballClubId",
                        column: x => x.FootballClubId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballPlayerPositions_FootballPlayerPositionId",
                        column: x => x.FootballPlayerPositionId,
                        principalTable: "FootballPlayerPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameWeeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<byte>(nullable: false),
                    Finished = table.Column<bool>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameWeeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameWeeks_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FootballPlayerImageUrl = table.Column<string>(nullable: false),
                    ShirtNumber = table.Column<byte>(nullable: false),
                    Height = table.Column<byte>(nullable: false),
                    Weight = table.Column<byte>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BirthPlace = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    FootballPlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayerInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FootballPlayerInfos_FootballPlayers_FootballPlayerId",
                        column: x => x.FootballPlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttackStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Goals = table.Column<short>(nullable: false),
                    PenaltiesScored = table.Column<short>(nullable: false),
                    FreeKicksScored = table.Column<short>(nullable: false),
                    Shots = table.Column<short>(nullable: false),
                    ShotsOnTarget = table.Column<short>(nullable: false),
                    HitWoodwork = table.Column<short>(nullable: false),
                    BigChancesMissed = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttackStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_AttackStatistics_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackStatistics_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefenceStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Tackles = table.Column<short>(nullable: false),
                    BlockedShots = table.Column<short>(nullable: false),
                    Interceptions = table.Column<short>(nullable: false),
                    Clearances = table.Column<short>(nullable: false),
                    HeadedClearance = table.Column<short>(nullable: false),
                    Recoveries = table.Column<short>(nullable: false),
                    DuelsWon = table.Column<short>(nullable: false),
                    DuelsLost = table.Column<short>(nullable: false),
                    SuccessfulFiftyFifties = table.Column<short>(nullable: false),
                    AerialBattlesWon = table.Column<short>(nullable: false),
                    AerialBattlesLost = table.Column<short>(nullable: false),
                    CleanSheets = table.Column<short>(nullable: false),
                    GoalsConceded = table.Column<short>(nullable: false),
                    LastManTackles = table.Column<short>(nullable: false),
                    OwnGoals = table.Column<short>(nullable: false),
                    ErrorsLeadingToGoal = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefenceStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_DefenceStatistics_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefenceStatistics_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    YellowCards = table.Column<short>(nullable: false),
                    RedCards = table.Column<short>(nullable: false),
                    Fouls = table.Column<short>(nullable: false),
                    Offsides = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_DisciplineStatistics_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineStatistics_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FantasyUserSquad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Transfers = table.Column<short>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    GameweekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyUserSquad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyUserSquad_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FantasyUserSquad_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTimeStart = table.Column<DateTime>(nullable: true),
                    Finished = table.Column<bool>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    AwayTeamId = table.Column<int>(nullable: false),
                    GameWeekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_FootballClubs_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fixtures_GameWeeks_GameWeekId",
                        column: x => x.GameWeekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixtures_FootballClubs_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoalkeepingStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Saves = table.Column<short>(nullable: false),
                    PenaltiesSaved = table.Column<short>(nullable: false),
                    Punches = table.Column<short>(nullable: false),
                    HighClaims = table.Column<short>(nullable: false),
                    Catches = table.Column<short>(nullable: false),
                    SweeperClearances = table.Column<short>(nullable: false),
                    GoalKicks = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalkeepingStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GoalkeepingStatistics_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalkeepingStatistics_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Appearances = table.Column<short>(nullable: false),
                    Wins = table.Column<short>(nullable: false),
                    Losses = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_MatchStatistics_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchStatistics_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Assists = table.Column<short>(nullable: false),
                    Passes = table.Column<short>(nullable: false),
                    BigChancesCreated = table.Column<short>(nullable: false),
                    Crosses = table.Column<short>(nullable: false),
                    ThroughBalls = table.Column<short>(nullable: false),
                    AccurateLongBalls = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_TeamPlayStatistics_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayStatistics_FootballPlayers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FantasyUserPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsFirstTeam = table.Column<bool>(nullable: false),
                    FootballPlayerId = table.Column<int>(nullable: false),
                    FantasyUserSquadId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyUserPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyUserPlayers_FantasyUserSquad_FantasyUserSquadId",
                        column: x => x.FantasyUserSquadId,
                        principalTable: "FantasyUserSquad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FantasyUserPlayers_FootballPlayers_FootballPlayerId",
                        column: x => x.FootballPlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FootballClubId",
                table: "AspNetUsers",
                column: "FootballClubId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttackStatistics_GameweekId",
                table: "AttackStatistics",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceStatistics_GameweekId",
                table: "DefenceStatistics",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStatistics_GameweekId",
                table: "DisciplineStatistics",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyUserPlayers_FantasyUserSquadId",
                table: "FantasyUserPlayers",
                column: "FantasyUserSquadId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyUserPlayers_FootballPlayerId",
                table: "FantasyUserPlayers",
                column: "FootballPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyUserSquad_GameweekId",
                table: "FantasyUserSquad",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyUserSquad_UserId",
                table: "FantasyUserSquad",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_AwayTeamId",
                table: "Fixtures",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_GameWeekId",
                table: "Fixtures",
                column: "GameWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_HomeTeamId",
                table: "Fixtures",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballClubInfos_FootballClubId",
                table: "FootballClubInfos",
                column: "FootballClubId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayerInfos_FootballPlayerId",
                table: "FootballPlayerInfos",
                column: "FootballPlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballClubId",
                table: "FootballPlayers",
                column: "FootballClubId");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballPlayerPositionId",
                table: "FootballPlayers",
                column: "FootballPlayerPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameWeeks_SeasonId",
                table: "GameWeeks",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalkeepingStatistics_GameweekId",
                table: "GoalkeepingStatistics",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_GameweekId",
                table: "MatchStatistics",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayStatistics_GameweekId",
                table: "TeamPlayStatistics",
                column: "GameweekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttackStatistics");

            migrationBuilder.DropTable(
                name: "DefenceStatistics");

            migrationBuilder.DropTable(
                name: "DisciplineStatistics");

            migrationBuilder.DropTable(
                name: "FantasyUserPlayers");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "FootballClubInfos");

            migrationBuilder.DropTable(
                name: "FootballPlayerInfos");

            migrationBuilder.DropTable(
                name: "GoalkeepingStatistics");

            migrationBuilder.DropTable(
                name: "MatchStatistics");

            migrationBuilder.DropTable(
                name: "TeamPlayStatistics");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FantasyUserSquad");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "GameWeeks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FootballPlayerPositions");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "FootballClubs");
        }
    }
}
