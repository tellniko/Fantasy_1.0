using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class match : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FootballPlayerId",
                table: "MatchStatistics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchStatistics_FootballPlayerId",
                table: "MatchStatistics",
                column: "FootballPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchStatistics_FootballPlayers_FootballPlayerId",
                table: "MatchStatistics",
                column: "FootballPlayerId",
                principalTable: "FootballPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchStatistics_FootballPlayers_FootballPlayerId",
                table: "MatchStatistics");

            migrationBuilder.DropIndex(
                name: "IX_MatchStatistics_FootballPlayerId",
                table: "MatchStatistics");

            migrationBuilder.DropColumn(
                name: "FootballPlayerId",
                table: "MatchStatistics");
        }
    }
}
