using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class scores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                table: "GameweeksStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_Gameweeks_GameweekId",
                table: "GameweeksStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameweeksStatuses",
                table: "GameweeksStatuses");

            migrationBuilder.RenameTable(
                name: "GameweeksStatuses",
                newName: "GameweekStatus");

            migrationBuilder.RenameIndex(
                name: "IX_GameweeksStatuses_GameweekId",
                table: "GameweekStatus",
                newName: "IX_GameweekStatus_GameweekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameweekStatus",
                table: "GameweekStatus",
                columns: new[] { "FantasyPlayerId", "GameweekId" });

            migrationBuilder.CreateTable(
                name: "GameweekScores",
                columns: table => new
                {
                    FantasyUserId = table.Column<string>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Score = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweekScores", x => new { x.FantasyUserId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweekScores_AspNetUsers_FantasyUserId",
                        column: x => x.FantasyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweekScores_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameweekScores_GameweekId",
                table: "GameweekScores",
                column: "GameweekId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameweekStatus_FantasyPlayers_FantasyPlayerId",
                table: "GameweekStatus",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameweekStatus_Gameweeks_GameweekId",
                table: "GameweekStatus",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweekStatus_FantasyPlayers_FantasyPlayerId",
                table: "GameweekStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_GameweekStatus_Gameweeks_GameweekId",
                table: "GameweekStatus");

            migrationBuilder.DropTable(
                name: "GameweekScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameweekStatus",
                table: "GameweekStatus");

            migrationBuilder.RenameTable(
                name: "GameweekStatus",
                newName: "GameweeksStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_GameweekStatus_GameweekId",
                table: "GameweeksStatuses",
                newName: "IX_GameweeksStatuses_GameweekId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameweeksStatuses",
                table: "GameweeksStatuses",
                columns: new[] { "FantasyPlayerId", "GameweekId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                table: "GameweeksStatuses",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksStatuses_Gameweeks_GameweekId",
                table: "GameweeksStatuses",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
