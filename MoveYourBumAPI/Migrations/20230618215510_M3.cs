using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoveYourBumAPI.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayExercise_Exercise_IdExercise",
                table: "DayExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_DayExercise_Schedule_IdSchedule",
                table: "DayExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_DayExerciseSet_DayExercise_IdScheduleExercise",
                table: "DayExerciseSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayExerciseSet",
                table: "DayExerciseSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayExercise",
                table: "DayExercise");

            migrationBuilder.RenameTable(
                name: "DayExerciseSet",
                newName: "ScheduleExerciseSet");

            migrationBuilder.RenameTable(
                name: "DayExercise",
                newName: "ScheduleExercise");

            migrationBuilder.RenameIndex(
                name: "IX_DayExerciseSet_IdScheduleExercise",
                table: "ScheduleExerciseSet",
                newName: "IX_ScheduleExerciseSet_IdScheduleExercise");

            migrationBuilder.RenameIndex(
                name: "IX_DayExercise_IdSchedule",
                table: "ScheduleExercise",
                newName: "IX_ScheduleExercise_IdSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_DayExercise_IdExercise",
                table: "ScheduleExercise",
                newName: "IX_ScheduleExercise_IdExercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleExerciseSet",
                table: "ScheduleExerciseSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleExercise",
                table: "ScheduleExercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExercise_Exercise_IdExercise",
                table: "ScheduleExercise",
                column: "IdExercise",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExercise_Schedule_IdSchedule",
                table: "ScheduleExercise",
                column: "IdSchedule",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExerciseSet_ScheduleExercise_IdScheduleExercise",
                table: "ScheduleExerciseSet",
                column: "IdScheduleExercise",
                principalTable: "ScheduleExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExercise_Exercise_IdExercise",
                table: "ScheduleExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExercise_Schedule_IdSchedule",
                table: "ScheduleExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExerciseSet_ScheduleExercise_IdScheduleExercise",
                table: "ScheduleExerciseSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleExerciseSet",
                table: "ScheduleExerciseSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleExercise",
                table: "ScheduleExercise");

            migrationBuilder.RenameTable(
                name: "ScheduleExerciseSet",
                newName: "DayExerciseSet");

            migrationBuilder.RenameTable(
                name: "ScheduleExercise",
                newName: "DayExercise");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleExerciseSet_IdScheduleExercise",
                table: "DayExerciseSet",
                newName: "IX_DayExerciseSet_IdScheduleExercise");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleExercise_IdSchedule",
                table: "DayExercise",
                newName: "IX_DayExercise_IdSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduleExercise_IdExercise",
                table: "DayExercise",
                newName: "IX_DayExercise_IdExercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayExerciseSet",
                table: "DayExerciseSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayExercise",
                table: "DayExercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DayExercise_Exercise_IdExercise",
                table: "DayExercise",
                column: "IdExercise",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayExercise_Schedule_IdSchedule",
                table: "DayExercise",
                column: "IdSchedule",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayExerciseSet_DayExercise_IdScheduleExercise",
                table: "DayExerciseSet",
                column: "IdScheduleExercise",
                principalTable: "DayExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
