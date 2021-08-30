using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InintialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "OfficeId", "Address", "Country", "Name" },
                values: new object[] { 1, "test", "USA", "Office Number 1" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "OfficeId", "Address", "Country", "Name" },
                values: new object[] { 2, "test", "USA", "Office Number 1" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Name", "OfficeId", "Patronomic", "Position", "SecondName" },
                values: new object[] { 1, 26, "Sam", 1, "Olovson", "Software developer", "Raiden" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Name", "OfficeId", "Patronomic", "Position", "SecondName" },
                values: new object[] { 2, 26, "Tom", 2, "Olovson", "Junior", "Potter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "OfficeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "OfficeId",
                keyValue: 2);
        }
    }
}
