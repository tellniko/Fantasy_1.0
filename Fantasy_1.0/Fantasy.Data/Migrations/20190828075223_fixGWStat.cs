using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class fixGWStat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweekStatistics_FootballPlayers_FootballPlayerId",
                table: "GameweekStatistics");

            migrationBuilder.DropIndex(
                name: "IX_GameweekStatistics_FootballPlayerId",
                table: "GameweekStatistics");

            migrationBuilder.DropColumn(
                name: "FootballPlayerId",
                table: "GameweekStatistics");

            migrationBuilder.AddForeignKey(
                name: "FK_GameweekStatistics_FootballPlayers_PlayerId",
                table: "GameweekStatistics",
                column: "PlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweekStatistics_FootballPlayers_PlayerId",
                table: "GameweekStatistics");

            migrationBuilder.AddColumn<int>(
                name: "FootballPlayerId",
                table: "GameweekStatistics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameweekStatistics_FootballPlayerId",
                table: "GameweekStatistics",
                column: "FootballPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameweekStatistics_FootballPlayers_FootballPlayerId",
                table: "GameweekStatistics",
                column: "FootballPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
