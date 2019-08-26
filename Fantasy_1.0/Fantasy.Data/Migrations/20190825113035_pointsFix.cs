using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class pointsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksPoints_FootballPlayers_GameweekId",
                table: "GameweeksPoints");

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksPoints_FootballPlayers_FootbalPlayerId",
                table: "GameweeksPoints",
                column: "FootbalPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksPoints_FootballPlayers_FootbalPlayerId",
                table: "GameweeksPoints");

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksPoints_FootballPlayers_GameweekId",
                table: "GameweeksPoints",
                column: "GameweekId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
