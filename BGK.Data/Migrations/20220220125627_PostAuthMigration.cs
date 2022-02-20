using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class nenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembersCount = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tin = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BirthDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactLecturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLecturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactLecturer_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MembersCount = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LecturerReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturerReview_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerReview_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LecturerReview_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    LecturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topic_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_Lecturer_LecturerId",
                        column: x => x.LecturerId,
                        principalTable: "Lecturer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topic_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingReview_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingReview_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingReview_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_EventId",
                table: "Client",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactLecturer_LecturerId",
                table: "ContactLecturer",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ClassroomId",
                table: "Event",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CompanyId",
                table: "Event",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LecturerId",
                table: "Event",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerReview_ClientId",
                table: "LecturerReview",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerReview_CompanyId",
                table: "LecturerReview",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerReview_LecturerId",
                table: "LecturerReview",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ClientId",
                table: "Topic",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_LecturerId",
                table: "Topic",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_TrainingId",
                table: "Topic",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_LecturerId",
                table: "Training",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingReview_ClientId",
                table: "TrainingReview",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingReview_CompanyId",
                table: "TrainingReview",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingReview_TrainingId",
                table: "TrainingReview",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ContactLecturer");

            migrationBuilder.DropTable(
                name: "LecturerReview");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "TrainingReview");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Classroom");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Lecturer");
        }
    }
}
