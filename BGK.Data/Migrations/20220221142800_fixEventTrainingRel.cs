using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class fixEventTrainingRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Classroom_ClassroomId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_TrainingId",
                table: "Event",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Classroom_ClassroomId",
                table: "Event",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Training_TrainingId",
                table: "Event",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Classroom_ClassroomId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Training_TrainingId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_TrainingId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Classroom_ClassroomId",
                table: "Event",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
