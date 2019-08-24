using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy.Data.Migrations
{
    public partial class fantasyPlayerStatusFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttackStatistics_GameWeeks_GameweekId",
                table: "AttackStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_DefenceStatistics_GameWeeks_GameweekId",
                table: "DefenceStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineStatistics_GameWeeks_GameweekId",
                table: "DisciplineStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_GameWeeks_GameWeekId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_GameWeeks_GameweekId",
                table: "GameweeksStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalkeepingStatistics_GameWeeks_GameweekId",
                table: "GoalkeepingStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchStatistics_GameWeeks_GameweekId",
                table: "MatchStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayStatistics_GameWeeks_GameweekId",
                table: "TeamPlayStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameWeeks",
                table: "GameWeeks");

            migrationBuilder.RenameTable(
                name: "GameWeeks",
                newName: "Gameweeks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gameweeks",
                table: "Gameweeks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttackStatistics_Gameweeks_GameweekId",
                table: "AttackStatistics",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceStatistics_Gameweeks_GameweekId",
                table: "DefenceStatistics",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineStatistics_Gameweeks_GameweekId",
                table: "DisciplineStatistics",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Gameweeks_GameWeekId",
                table: "Fixtures",
                column: "GameWeekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksStatuses_Gameweeks_GameweekId",
                table: "GameweeksStatuses",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalkeepingStatistics_Gameweeks_GameweekId",
                table: "GoalkeepingStatistics",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchStatistics_Gameweeks_GameweekId",
                table: "MatchStatistics",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayStatistics_Gameweeks_GameweekId",
                table: "TeamPlayStatistics",
                column: "GameweekId",
                principalTable: "Gameweeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttackStatistics_Gameweeks_GameweekId",
                table: "AttackStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_DefenceStatistics_Gameweeks_GameweekId",
                table: "DefenceStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineStatistics_Gameweeks_GameweekId",
                table: "DisciplineStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Gameweeks_GameWeekId",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_GameweeksStatuses_Gameweeks_GameweekId",
                table: "GameweeksStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_GoalkeepingStatistics_Gameweeks_GameweekId",
                table: "GoalkeepingStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchStatistics_Gameweeks_GameweekId",
                table: "MatchStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayStatistics_Gameweeks_GameweekId",
                table: "TeamPlayStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gameweeks",
                table: "Gameweeks");

            migrationBuilder.RenameTable(
                name: "Gameweeks",
                newName: "GameWeeks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameWeeks",
                table: "GameWeeks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttackStatistics_GameWeeks_GameweekId",
                table: "AttackStatistics",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DefenceStatistics_GameWeeks_GameweekId",
                table: "DefenceStatistics",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineStatistics_GameWeeks_GameweekId",
                table: "DisciplineStatistics",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_GameWeeks_GameWeekId",
                table: "Fixtures",
                column: "GameWeekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameweeksStatuses_GameWeeks_GameweekId",
                table: "GameweeksStatuses",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoalkeepingStatistics_GameWeeks_GameweekId",
                table: "GoalkeepingStatistics",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchStatistics_GameWeeks_GameweekId",
                table: "MatchStatistics",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayStatistics_GameWeeks_GameweekId",
                table: "TeamPlayStatistics",
                column: "GameweekId",
                principalTable: "GameWeeks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
