using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class newLectured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Training_Lecturer_LecturerId",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Training_LecturerId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Training");

            migrationBuilder.CreateTable(
                name: "LecturerTraining",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    TrainingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerTraining", x => new { x.LecturerId, x.TrainingsId });
                    table.ForeignKey(
                        name: "FK_LecturerTraining_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerTraining_Training_TrainingsId",
                        column: x => x.TrainingsId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LecturerTraining_TrainingsId",
                table: "LecturerTraining",
                column: "TrainingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerTraining");

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "Training",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Training_LecturerId",
                table: "Training",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Training_Lecturer_LecturerId",
                table: "Training",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id");
        }
    }
}
