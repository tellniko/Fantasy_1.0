using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class fantasyplayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_FootballClubs_FootballClubId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FantasyUserPlayers");

            migrationBuilder.DropTable(
                name: "FantasyUserSquad");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FootballClubId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FootballClubId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "FantasyPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FootballPlayerId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
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
                name: "FantasyPlayerStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCaptain = table.Column<bool>(nullable: false),
                    IsBenched = table.Column<bool>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    FantasyPlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FantasyPlayerStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                        column: x => x.FantasyPlayerId,
                        principalTable: "FantasyPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FantasyPlayerStatuses_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPlayers_FantasyUserId",
                table: "FantasyPlayers",
                column: "FantasyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPlayers_FootballPlayerId",
                table: "FantasyPlayers",
                column: "FootballPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPlayerStatuses_FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                column: "FantasyPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPlayerStatuses_GameweekId",
                table: "FantasyPlayerStatuses",
                column: "GameweekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FantasyPlayerStatuses");

            migrationBuilder.DropTable(
                name: "FantasyPlayers");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FootballClubId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FantasyUserSquad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameweekId = table.Column<int>(nullable: false),
                    Transfers = table.Column<short>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
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
                name: "FantasyUserPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FantasyUserSquadId = table.Column<int>(nullable: true),
                    FootballPlayerId = table.Column<int>(nullable: false),
                    IsFirstTeam = table.Column<bool>(nullable: false)
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
                name: "IX_AspNetUsers_FootballClubId",
                table: "AspNetUsers",
                column: "FootballClubId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_FootballClubs_FootballClubId",
                table: "AspNetUsers",
                column: "FootballClubId",
                principalTable: "FootballClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
