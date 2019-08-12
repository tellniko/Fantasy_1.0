using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class tablePLayerInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FootballPlayerImageUrl",
                table: "FootballPlayerInfos",
                newName: "BigImgUrl");

            migrationBuilder.AddColumn<string>(
                name: "SmallImgUrl",
                table: "FootballPlayerInfos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmallImgUrl",
                table: "FootballPlayerInfos");

            migrationBuilder.RenameColumn(
                name: "BigImgUrl",
                table: "FootballPlayerInfos",
                newName: "FootballPlayerImageUrl");
        }
    }
}
