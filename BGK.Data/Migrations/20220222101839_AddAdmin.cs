using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BearGoodbyeKolkhozProject.Data.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "BirthDay", "Email", "Gender", "IsDeleted", "LastName", "Name", "Password", "Role" },
                values: new object[] { 1, "01.01.2000", "qwe@mail.ru", 1, false, "Admin", "Admin", "12345qwe", 1 });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "Id", "Address", "City", "IsDeleted", "MembersCount" },
                values: new object[,]
                {
                    { 1, "ул. Вавилова дом 5", "Санкт-Петербург", false, 25 },
                    { 2, "пр. Ветеранов дом 8", "Санкт-Петербург", false, 25 },
                    { 3, "ул. Пушкина дом 27", "Санкт-Петербург", false, 40 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
