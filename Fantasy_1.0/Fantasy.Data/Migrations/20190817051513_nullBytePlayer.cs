using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class nullBytePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Weight",
                table: "FootballPlayerInfos",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<string>(
                name: "SmallImgUrl",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "ShirtNumber",
                table: "FootballPlayerInfos",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<byte>(
                name: "Height",
                table: "FootballPlayerInfos",
                nullable: true,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Weight",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SmallImgUrl",
                table: "FootballPlayerInfos",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<byte>(
                name: "ShirtNumber",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "Height",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(byte),
                oldNullable: true);
        }
    }
}
