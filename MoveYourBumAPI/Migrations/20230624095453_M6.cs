using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoveYourBumAPI.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDaySchedule",
                table: "ScheduleExerciseSet",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Day",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleExerciseSet_IdDaySchedule",
                table: "ScheduleExerciseSet",
                column: "IdDaySchedule");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleExerciseSet_DaySchedule_IdDaySchedule",
                table: "ScheduleExerciseSet",
                column: "IdDaySchedule",
                principalTable: "DaySchedule",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleExerciseSet_DaySchedule_IdDaySchedule",
                table: "ScheduleExerciseSet");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleExerciseSet_IdDaySchedule",
                table: "ScheduleExerciseSet");

            migrationBuilder.DropColumn(
                name: "IdDaySchedule",
                table: "ScheduleExerciseSet");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercise",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Day",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
