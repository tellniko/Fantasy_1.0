using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class userTableChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameweekScores");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "SquadName",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GameweekScore",
                columns: table => new
                {
                    FantasyUserId = table.Column<string>(nullable: false),
                    GameweekId = table.Column<int>(nullable: false),
                    Score = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameweekScore", x => new { x.FantasyUserId, x.GameweekId });
                    table.ForeignKey(
                        name: "FK_GameweekScore_AspNetUsers_FantasyUserId",
                        column: x => x.FantasyUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameweekScore_Gameweeks_GameweekId",
                        column: x => x.GameweekId,
                        principalTable: "Gameweeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameweekScore_GameweekId",
                table: "GameweekScore",
                column: "GameweekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameweekScore");

            migrationBuilder.AlterColumn<string>(
                name: "SquadName",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
