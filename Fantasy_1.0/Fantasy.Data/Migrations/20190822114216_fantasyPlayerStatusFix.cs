using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class fantasyPlayerStatusFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                table: "FantasyPlayerStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_FantasyPlayerStatuses_GameWeeks_GameweekId",
                table: "FantasyPlayerStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FantasyPlayerStatuses",
                table: "FantasyPlayerStatuses");

            migrationBuilder.DropIndex(
                name: "IX_FantasyPlayerStatuses_GameweekId",
                table: "FantasyPlayerStatuses");

            migrationBuilder.DropColumn(
                name: "GameweekId",
                table: "FantasyPlayerStatuses");

            migrationBuilder.RenameTable(
                name: "FantasyPlayerStatuses",
                newName: "Statuses");

            migrationBuilder.RenameIndex(
                name: "IX_FantasyPlayerStatuses_FantasyPlayerId",
                table: "Statuses",
                newName: "IX_Statuses_FantasyPlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GameweeksStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    IsCaptain = table.Column<bool>(nullable: false),
                    IsBenched = table.Column<bool>(nullable: false),
                    FantasyPlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweeksStatuses", x => new { x.StatusId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                        column: x => x.FantasyPlayerId,
                        principalTable: "FantasyPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameweeksStatuses_GameWeeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "GameWeeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweeksStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameweeksStatuses_FantasyPlayerId",
                table: "GameweeksStatuses",
                column: "FantasyPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameweeksStatuses_GameweekId",
                table: "GameweeksStatuses",
                column: "GameweekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_FantasyPlayers_FantasyPlayerId",
                table: "Statuses",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_FantasyPlayers_FantasyPlayerId",
                table: "Statuses");

            migrationBuilder.DropTable(
                name: "GameweeksStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "FantasyPlayerStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_Statuses_FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                newName: "IX_FantasyPlayerStatuses_FantasyPlayerId");

            migrationBuilder.AddColumn<int>(
                name: "GameweekId",
                table: "FantasyPlayerStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FantasyPlayerStatuses",
                table: "FantasyPlayerStatuses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FantasyPlayerStatuses_GameweekId",
                table: "FantasyPlayerStatuses",
                column: "GameweekId");

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyPlayerStatuses_FantasyPlayers_FantasyPlayerId",
                table: "FantasyPlayerStatuses",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FantasyPlayerStatuses_GameWeeks_GameweekId",
                table: "FantasyPlayerStatuses",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
