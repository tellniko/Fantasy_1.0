using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class rebuild : Migration
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
                    SquadName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballClubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(maxLength: 50, nullable: false),
                    Tag = table.Column<string>(nullable: false),
                    Playable = table.Column<bool>(nullable: false),
                    Rating = table.Column<byte>(nullable: false),
                    BadgeImgUrl = table.Column<string>(nullable: true)
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
                name: "Gameweeks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Finished = table.Column<bool>(nullable: false),
                    Start = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gameweeks", x => x.Id);
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
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Home = table.Column<byte>(nullable: false),
                    Away = table.Column<byte>(nullable: false),
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
                        name: "FK_Fixtures_Gameweeks_GameWeekId",
                        column: x => x.GameWeekId,
                        principalTable: "Gameweeks",
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
                name: "GameweeksScores",
                columns: table => new
                {
                    FantasyUserId = table.Column<string>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Score = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweeksScores", x => new { x.FantasyUserId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweeksScores_AspNetUsers_FantasyUserId",
                        column: x => x.FantasyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweeksScores_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FantasyPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FootballPlayerId = table.Column<int>(nullable: false),
                    FantasyUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyPlayers_AspNetUsers_FantasyUserId",
                        column: x => x.FantasyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FantasyPlayers_FootballPlayers_FootballPlayerId",
                        column: x => x.FootballPlayerId,
                        principalTable: "FootballPlayers",
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
                    BigImgUrl = table.Column<string>(nullable: true),
                    SmallImgUrl = table.Column<string>(nullable: true),
                    ShirtNumber = table.Column<byte>(nullable: true),
                    Height = table.Column<byte>(nullable: true),
                    Weight = table.Column<byte>(nullable: true),
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
                name: "GameweeksPoints",
                columns: table => new
                {
                    FootbalPlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Points = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweeksPoints", x => new { x.FootbalPlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweeksPoints_FootballPlayers_FootbalPlayerId",
                        column: x => x.FootbalPlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweeksPoints_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameweekStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    FootballPlayerId = table.Column<int>(nullable: true),
                    Goals = table.Column<short>(nullable: false),
                    PenaltiesScored = table.Column<short>(nullable: false),
                    FreeKicksScored = table.Column<short>(nullable: false),
                    Shots = table.Column<short>(nullable: false),
                    ShotsOnTarget = table.Column<short>(nullable: false),
                    HitWoodwork = table.Column<short>(nullable: false),
                    BigChancesMissed = table.Column<short>(nullable: false),
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
                    ErrorsLeadingToGoal = table.Column<short>(nullable: false),
                    YellowCards = table.Column<short>(nullable: false),
                    RedCards = table.Column<short>(nullable: false),
                    Fouls = table.Column<short>(nullable: false),
                    Offsides = table.Column<short>(nullable: false),
                    Saves = table.Column<short>(nullable: false),
                    PenaltiesSaved = table.Column<short>(nullable: false),
                    Punches = table.Column<short>(nullable: false),
                    HighClaims = table.Column<short>(nullable: false),
                    Catches = table.Column<short>(nullable: false),
                    SweeperClearances = table.Column<short>(nullable: false),
                    GoalKicks = table.Column<short>(nullable: false),
                    Appearances = table.Column<short>(nullable: false),
                    Wins = table.Column<short>(nullable: false),
                    Losses = table.Column<short>(nullable: false),
                    Assists = table.Column<short>(nullable: false),
                    Passes = table.Column<short>(nullable: false),
                    BigChancesCreated = table.Column<short>(nullable: false),
                    Crosses = table.Column<short>(nullable: false),
                    ThroughBalls = table.Column<short>(nullable: false),
                    AccurateLongBalls = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweekStatistics", x => new { x.PlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweekStatistics_FootballPlayers_FootballPlayerId",
                        column: x => x.FootballPlayerId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameweekStatistics_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameweeksStatuses",
                columns: table => new
                {
                    FantasyPlayerId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    IsCaptain = table.Column<bool>(nullable: false),
                    IsBenched = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweeksStatuses", x => new { x.FantasyPlayerId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                        column: x => x.FantasyPlayerId,
                        principalTable: "FantasyPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweeksStatuses_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
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
                name: "IX_FantasyPlayers_FantasyUserId",
                table: "FantasyPlayers",
                column: "FantasyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPlayers_FootballPlayerId",
                table: "FantasyPlayers",
                column: "FootballPlayerId");

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
                name: "IX_GameweeksPoints_GameweekId",
                table: "GameweeksPoints",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_GameweeksScores_GameweekId",
                table: "GameweeksScores",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_GameweeksStatuses_GameweekId",
                table: "GameweeksStatuses",
                column: "GameweekId");

            migrationBuilder.CreateIndex(
                name: "IX_GameweekStatistics_FootballPlayerId",
                table: "GameweekStatistics",
                column: "FootballPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameweekStatistics_GameweekId",
                table: "GameweekStatistics",
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
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "FootballPlayerInfos");

            migrationBuilder.DropTable(
                name: "GameweeksPoints");

            migrationBuilder.DropTable(
                name: "GameweeksScores");

            migrationBuilder.DropTable(
                name: "GameweeksStatuses");

            migrationBuilder.DropTable(
                name: "GameweekStatistics");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FantasyPlayers");

            migrationBuilder.DropTable(
                name: "Gameweeks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "FootballClubs");

            migrationBuilder.DropTable(
                name: "FootballPlayerPositions");
        }
    }
}
