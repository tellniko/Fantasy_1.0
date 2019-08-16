using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class shortByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Weight",
                table: "FootballPlayerInfos",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<short>(
                name: "ShirtNumber",
                table: "FootballPlayerInfos",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<short>(
                name: "Height",
                table: "FootballPlayerInfos",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Weight",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(short),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<byte>(
                name: "ShirtNumber",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(short),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<byte>(
                name: "Height",
                table: "FootballPlayerInfos",
                nullable: false,
                oldClrType: typeof(short),
                oldMaxLength: 255);
        }
    }
}
