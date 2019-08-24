using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class gwStatusFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                table: "GameweeksStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_Statuses_StatusId",
                table: "GameweeksStatuses");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameweeksStatuses",
                table: "GameweeksStatuses");

            migrationBuilder.DropIndex(
                name: "IX_GameweeksStatuses_FantasyPlayerId",
                table: "GameweeksStatuses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "GameweeksStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "FantasyPlayerId",
                table: "GameweeksStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                table: "GameweeksStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameweeksStatuses",
                table: "GameweeksStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "FantasyPlayerId",
                table: "GameweeksStatuses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "GameweeksStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameweeksStatuses",
                table: "GameweeksStatuses",
                columns: new[] { "StatusId", "GameweekId" });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FantasyPlayerId = table.Column<int>(nullable: false),
                    IsBenched = table.Column<bool>(nullable: false),
                    IsCaptain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_FantasyPlayers_FantasyPlayerId",
                        column: x => x.FantasyPlayerId,
                        principalTable: "FantasyPlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameweeksStatuses_FantasyPlayerId",
                table: "GameweeksStatuses",
                column: "FantasyPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_FantasyPlayerId",
                table: "Statuses",
                column: "FantasyPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksStatuses_FantasyPlayers_FantasyPlayerId",
                table: "GameweeksStatuses",
                column: "FantasyPlayerId",
                principalTable: "FantasyPlayers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksStatuses_Statuses_StatusId",
                table: "GameweeksStatuses",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
