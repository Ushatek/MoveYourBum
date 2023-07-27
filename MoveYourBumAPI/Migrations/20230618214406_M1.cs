using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoveYourBumAPI.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayExercise_Day_IdDay",
                table: "DayExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_DayExerciseSet_DayExercise_IdDayExercise",
                table: "DayExerciseSet");


            migrationBuilder.RenameColumn(
                name: "IdDayExercise",
                table: "DayExerciseSet",
                newName: "IdScheduleExercise");

            migrationBuilder.RenameIndex(
                name: "IX_DayExerciseSet_IdDayExercise",
                table: "DayExerciseSet",
                newName: "IX_DayExerciseSet_IdScheduleExercise");

            migrationBuilder.RenameColumn(
                name: "IdDay",
                table: "DayExercise",
                newName: "IdSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_DayExercise_IdDay",
                table: "DayExercise",
                newName: "IX_DayExercise_IdSchedule");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayExercise_Schedule_IdSchedule",
                table: "DayExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_DayExerciseSet_DayExercise_IdScheduleExercise",
                table: "DayExerciseSet");

            migrationBuilder.RenameColumn(
                name: "IdScheduleExercise",
                table: "DayExerciseSet",
                newName: "IdDayExercise");

            migrationBuilder.RenameIndex(
                name: "IX_DayExerciseSet_IdScheduleExercise",
                table: "DayExerciseSet",
                newName: "IX_DayExerciseSet_IdDayExercise");

            migrationBuilder.RenameColumn(
                name: "IdSchedule",
                table: "DayExercise",
                newName: "IdDay");

            migrationBuilder.RenameIndex(
                name: "IX_DayExercise_IdSchedule",
                table: "DayExercise",
                newName: "IX_DayExercise_IdDay");

            migrationBuilder.CreateTable(
                name: "ExerciseSchedule",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    SchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSchedule", x => new { x.ExercisesId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_ExerciseSchedule_Exercise_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSchedule_Schedule_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSchedule_SchedulesId",
                table: "ExerciseSchedule",
                column: "SchedulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayExercise_Day_IdDay",
                table: "DayExercise",
                column: "IdDay",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayExerciseSet_DayExercise_IdDayExercise",
                table: "DayExerciseSet",
                column: "IdDayExercise",
                principalTable: "DayExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
