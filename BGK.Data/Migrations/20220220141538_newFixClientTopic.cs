using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class newFixClientTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Client_ClientId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Lecturer_LecturerId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_ClientId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_LecturerId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "Topic");

            migrationBuilder.CreateTable(
                name: "ClientTopic",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTopic", x => new { x.ClientId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_ClientTopic_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTopic_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTopic_TopicId",
                table: "ClientTopic",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTopic");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ClientId",
                table: "Topic",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LecturerId",
                table: "Topic",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Client_ClientId",
                table: "Topic",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Lecturer_LecturerId",
                table: "Topic",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id");
        }
    }
}
