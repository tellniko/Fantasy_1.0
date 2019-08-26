using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class points : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_GameweeksPoints_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweeksPoints_FootballPlayers_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "FootballPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameweeksPoints_GameweekId",
                table: "GameweeksPoints",
                column: "GameweekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameweeksPoints");
        }
    }
}
