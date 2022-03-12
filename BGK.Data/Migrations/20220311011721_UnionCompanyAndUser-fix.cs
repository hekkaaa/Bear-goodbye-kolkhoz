using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class UnionCompanyAndUserfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_userId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_userId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientEvent_Client_ClientsuserId",
                table: "ClientEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTopic_Client_ClientuserId",
                table: "ClientTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_userId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactLecturer_Lecturer_LectureruserId",
                table: "ContactLecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Company_CompanyuserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Lecturer_LectureruserId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_User_userId",
                table: "Lecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerReview_Client_ClientuserId",
                table: "LecturerReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerReview_Company_CompanyuserId",
                table: "LecturerReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerReview_Lecturer_LectureruserId",
                table: "LecturerReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerTraining_Lecturer_LectureruserId",
                table: "LecturerTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingReview_Client_ClientuserId",
                table: "TrainingReview");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingReview_Company_CompanyuserId",
                table: "TrainingReview");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyuserId",
                table: "TrainingReview",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "ClientuserId",
                table: "TrainingReview",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingReview_CompanyuserId",
                table: "TrainingReview",
                newName: "IX_TrainingReview_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingReview_ClientuserId",
                table: "TrainingReview",
                newName: "IX_TrainingReview_ClientId");

            migrationBuilder.RenameColumn(
                name: "LectureruserId",
                table: "LecturerTraining",
                newName: "LecturerId");

            migrationBuilder.RenameColumn(
                name: "LectureruserId",
                table: "LecturerReview",
                newName: "LecturerId");

            migrationBuilder.RenameColumn(
                name: "CompanyuserId",
                table: "LecturerReview",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "ClientuserId",
                table: "LecturerReview",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerReview_LectureruserId",
                table: "LecturerReview",
                newName: "IX_LecturerReview_LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerReview_CompanyuserId",
                table: "LecturerReview",
                newName: "IX_LecturerReview_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerReview_ClientuserId",
                table: "LecturerReview",
                newName: "IX_LecturerReview_ClientId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Lecturer",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LectureruserId",
                table: "Event",
                newName: "LecturerId");

            migrationBuilder.RenameColumn(
                name: "CompanyuserId",
                table: "Event",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_LectureruserId",
                table: "Event",
                newName: "IX_Event_LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_CompanyuserId",
                table: "Event",
                newName: "IX_Event_CompanyId");

            migrationBuilder.RenameColumn(
                name: "LectureruserId",
                table: "ContactLecturer",
                newName: "LecturerId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactLecturer_LectureruserId",
                table: "ContactLecturer",
                newName: "IX_ContactLecturer_LecturerId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Company",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientuserId",
                table: "ClientTopic",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ClientsuserId",
                table: "ClientEvent",
                newName: "ClientsId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Client",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Admin",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_Id",
                table: "Admin",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_Id",
                table: "Client",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientEvent_Client_ClientsId",
                table: "ClientEvent",
                column: "ClientsId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTopic_Client_ClientId",
                table: "ClientTopic",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_Id",
                table: "Company",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactLecturer_Lecturer_LecturerId",
                table: "ContactLecturer",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Company_CompanyId",
                table: "Event",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_User_Id",
                table: "Lecturer",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerReview_Client_ClientId",
                table: "LecturerReview",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerReview_Company_CompanyId",
                table: "LecturerReview",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerReview_Lecturer_LecturerId",
                table: "LecturerReview",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerTraining_Lecturer_LecturerId",
                table: "LecturerTraining",
                column: "LecturerId",
                principalTable: "Lecturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingReview_Client_ClientId",
                table: "TrainingReview",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingReview_Company_CompanyId",
                table: "TrainingReview",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_Id",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_Id",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientEvent_Client_ClientsId",
                table: "ClientEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTopic_Client_ClientId",
                table: "ClientTopic");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_Id",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactLecturer_Lecturer_LecturerId",
                table: "ContactLecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Company_CompanyId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Lecturer_LecturerId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturer_User_Id",
                table: "Lecturer");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerReview_Client_ClientId",
                table: "LecturerReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerReview_Company_CompanyId",
                table: "LecturerReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerReview_Lecturer_LecturerId",
                table: "LecturerReview");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturerTraining_Lecturer_LecturerId",
                table: "LecturerTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingReview_Client_ClientId",
                table: "TrainingReview");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingReview_Company_CompanyId",
                table: "TrainingReview");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "TrainingReview",
                newName: "CompanyuserId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "TrainingReview",
                newName: "ClientuserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingReview_CompanyId",
                table: "TrainingReview",
                newName: "IX_TrainingReview_CompanyuserId");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingReview_ClientId",
                table: "TrainingReview",
                newName: "IX_TrainingReview_ClientuserId");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "LecturerTraining",
                newName: "LectureruserId");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "LecturerReview",
                newName: "LectureruserId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "LecturerReview",
                newName: "CompanyuserId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "LecturerReview",
                newName: "ClientuserId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerReview_LecturerId",
                table: "LecturerReview",
                newName: "IX_LecturerReview_LectureruserId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerReview_CompanyId",
                table: "LecturerReview",
                newName: "IX_LecturerReview_CompanyuserId");

            migrationBuilder.RenameIndex(
                name: "IX_LecturerReview_ClientId",
                table: "LecturerReview",
                newName: "IX_LecturerReview_ClientuserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lecturer",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "Event",
                newName: "LectureruserId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Event",
                newName: "CompanyuserId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_LecturerId",
                table: "Event",
                newName: "IX_Event_LectureruserId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_CompanyId",
                table: "Event",
                newName: "IX_Event_CompanyuserId");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "ContactLecturer",
                newName: "LectureruserId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactLecturer_LecturerId",
                table: "ContactLecturer",
                newName: "IX_ContactLecturer_LectureruserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Company",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientTopic",
                newName: "ClientuserId");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "ClientEvent",
                newName: "ClientsuserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Client",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Admin",
                newName: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_userId",
                table: "Admin",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_userId",
                table: "Client",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientEvent_Client_ClientsuserId",
                table: "ClientEvent",
                column: "ClientsuserId",
                principalTable: "Client",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTopic_Client_ClientuserId",
                table: "ClientTopic",
                column: "ClientuserId",
                principalTable: "Client",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_userId",
                table: "Company",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactLecturer_Lecturer_LectureruserId",
                table: "ContactLecturer",
                column: "LectureruserId",
                principalTable: "Lecturer",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Company_CompanyuserId",
                table: "Event",
                column: "CompanyuserId",
                principalTable: "Company",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Lecturer_LectureruserId",
                table: "Event",
                column: "LectureruserId",
                principalTable: "Lecturer",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturer_User_userId",
                table: "Lecturer",
                column: "userId",
                principalTable: "User",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerReview_Client_ClientuserId",
                table: "LecturerReview",
                column: "ClientuserId",
                principalTable: "Client",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerReview_Company_CompanyuserId",
                table: "LecturerReview",
                column: "CompanyuserId",
                principalTable: "Company",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerReview_Lecturer_LectureruserId",
                table: "LecturerReview",
                column: "LectureruserId",
                principalTable: "Lecturer",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturerTraining_Lecturer_LectureruserId",
                table: "LecturerTraining",
                column: "LectureruserId",
                principalTable: "Lecturer",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingReview_Client_ClientuserId",
                table: "TrainingReview",
                column: "ClientuserId",
                principalTable: "Client",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingReview_Company_CompanyuserId",
                table: "TrainingReview",
                column: "CompanyuserId",
                principalTable: "Company",
                principalColumn: "userId");
        }
    }
}
