using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class Newtest1488 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainingId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_TrainingId",
                table: "Topic",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Training_TrainingId",
                table: "Topic",
                column: "TrainingId",
                principalTable: "Training",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Training_TrainingId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_TrainingId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Topic");
        }
    }
}
