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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FlagUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                    Rating = table.Column<byte>(nullable: false),
                    StadiumImgUrl = table.Column<string>(nullable: true),
                    Playable = table.Column<bool>(nullable: false),
                    ManagerName = table.Column<string>(nullable: true),
                    Ground = table.Column<string>(nullable: true),
                    PrimaryKitColor = table.Column<string>(nullable: true),
                    SecondaryKitColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPositions", x => x.Id);
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
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionId = table.Column<int>(nullable: false),
                    IsFirstTeam = table.Column<bool>(nullable: false),
                    IsInjured = table.Column<bool>(nullable: false),
                    IsPlayable = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    FootballClubId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_FootballClubs_FootballClubId",
                        column: x => x.FootballClubId,
                        principalTable: "FootballClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_PlayerPositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PlayerPositions",
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
                name: "PlayerPersonalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    FootballPlayerImageUrl = table.Column<string>(nullable: false),
                    ShirtNum = table.Column<byte>(nullable: false),
                    Height = table.Column<byte>(nullable: false),
                    Weight = table.Column<byte>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BirthPlace = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    BirthCountry = table.Column<string>(maxLength: 50, nullable: true),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPersonalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPersonalInfos_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "AttackStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AttackStatistics", x => new { x.PlayerId, x.FixtureId });
                    table.ForeignKey(
                        name: "FK_AttackStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttackStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
                    Appearances = table.Column<short>(nullable: false),
                    Wins = table.Column<short>(nullable: false),
                    Losses = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStatistics", x => new { x.PlayerId, x.FixtureId });
                    table.ForeignKey(
                        name: "FK_BaseStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefenceStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_DefenceStatistics", x => new { x.PlayerId, x.FixtureId });
                    table.ForeignKey(
                        name: "FK_DefenceStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefenceStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
                    YellowCards = table.Column<short>(nullable: false),
                    RedCards = table.Column<short>(nullable: false),
                    Fouls = table.Column<short>(nullable: false),
                    Offsides = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineStatistics", x => new { x.PlayerId, x.FixtureId });
                    table.ForeignKey(
                        name: "FK_DisciplineStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoalkeepingStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_GoalkeepingStatistics", x => new { x.PlayerId, x.FixtureId });
                    table.ForeignKey(
                        name: "FK_GoalkeepingStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalkeepingStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayStatistics",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FixtureId = table.Column<int>(nullable: false),
                    Assists = table.Column<short>(nullable: false),
                    Passes = table.Column<short>(nullable: false),
                    BigChancesCreated = table.Column<short>(nullable: false),
                    Crosses = table.Column<short>(nullable: false),
                    ThroughBalls = table.Column<short>(nullable: false),
                    AccurateLongBalls = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayStatistics", x => new { x.PlayerId, x.FixtureId });
                    table.ForeignKey(
                        name: "FK_TeamPlayStatistics_Fixtures_FixtureId",
                        column: x => x.FixtureId,
                        principalTable: "Fixtures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPlayStatistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
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
                name: "IX_AttackStatistics_FixtureId",
                table: "AttackStatistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseStatistics_FixtureId",
                table: "BaseStatistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_DefenceStatistics_FixtureId",
                table: "DefenceStatistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStatistics_FixtureId",
                table: "DisciplineStatistics",
                column: "FixtureId");

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
                name: "IX_GameWeeks_SeasonId",
                table: "GameWeeks",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalkeepingStatistics_FixtureId",
                table: "GoalkeepingStatistics",
                column: "FixtureId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPersonalInfos_PlayerId",
                table: "PlayerPersonalInfos",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_FootballClubId",
                table: "Players",
                column: "FootballClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayStatistics_FixtureId",
                table: "TeamPlayStatistics",
                column: "FixtureId");
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
                name: "BaseStatistics");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DefenceStatistics");

            migrationBuilder.DropTable(
                name: "DisciplineStatistics");

            migrationBuilder.DropTable(
                name: "GoalkeepingStatistics");

            migrationBuilder.DropTable(
                name: "PlayerPersonalInfos");

            migrationBuilder.DropTable(
                name: "TeamPlayStatistics");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "GameWeeks");

            migrationBuilder.DropTable(
                name: "FootballClubs");

            migrationBuilder.DropTable(
                name: "PlayerPositions");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
