using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class uniqueConstraintFCTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "FootballClubs",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_FootballClubs_Tag",
                table: "FootballClubs",
                column: "Tag",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FootballClubs_Tag",
                table: "FootballClubs");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "FootballClubs",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
