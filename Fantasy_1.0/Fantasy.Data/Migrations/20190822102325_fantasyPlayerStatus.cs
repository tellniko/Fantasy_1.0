using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class FantasyPlayerStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                table: "FantasyPlayerStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                table: "FantasyPlayerStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
