using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebServerPractical1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllDay = table.Column<bool>(type: "bit", nullable: false),
                    RecurrenceRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecurrenceException = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecurrenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeJobTitles",
                columns: table => new
                {
                    EmployeeJobTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeJobTitles", x => x.EmployeeJobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportToEmpId = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeJobTitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeJobTitles",
                columns: new[] { "EmployeeJobTitleId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Sales Manager", "SM" },
                    { 2, "Team Leader", "TL" },
                    { 3, "Sales Rep", "SR" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Email", "EmployeeJobTitleId", "FirstName", "Gender", "ImagePath", "LastName", "ReportToEmpId" },
                values: new object[,]
                {
                    { 1, new DateTime(1974, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "manoj@gmail.com", 1, "Manoj", "Male", "/Images/Profile/BobJones.jpg", "Pant", null },
                    { 2, new DateTime(1976, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "suraj.@oexl.com", 2, "Suraj", "Female", "/Images/Profile/JennyMarks.jpg", "Chand", 1 },
                    { 3, new DateTime(1981, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "henry.andrews@oexl.com", 2, "Henry", "Male", "/Images/Profile/HenryAndrews.jpg", "Andrews", 1 },
                    { 4, new DateTime(1984, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.jameson@oexl.com", 2, "John", "Male", "/Images/Profile/JohnJameson.jpg", "Jameson", 1 },
                    { 5, new DateTime(1993, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "noah.robinson@oexl.com", 3, "Noah", "Male", "/Images/Profile/NoahRobinson.jpg", "Robinson", 2 },
                    { 6, new DateTime(1993, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "elijah.hamilton@oexl.com", 3, "Elijah", "Male", "/Images/Profile/ElijahHamilton.jpg", "Hamilton", 2 },
                    { 7, new DateTime(1992, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jamie.fisher@oexl.com", 3, "Jamie", "Male", "/Images/Profile/JamieFisher.jpg", "Fisher", 2 },
                    { 8, new DateTime(1990, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.mills@oexl.com", 3, "Olivia", "Female", "/Images/Profile/OliviaMills.jpg", "Mills", 3 },
                    { 9, new DateTime(1993, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "benjamin.lucas@oexl.com", 3, "Benjamin", "Male", "/Images/Profile/BenjaminLucas.jpg", "Lucas", 3 },
                    { 10, new DateTime(1993, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.henderson@oexl.com", 3, "Sarah", "Female", "/Images/Profile/SarahHenderson.jpg", "Henderson", 3 },
                    { 11, new DateTime(1995, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.lee@oexl.com", 3, "Emma", "Female", "/Images/Profile/EmmaLee.jpg", "Lee", 4 },
                    { 12, new DateTime(1998, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ava.williams@oexl.com", 3, "Ava", "Female", "/Images/Profile/AvaWilliams.jpg", "Williams", 4 },
                    { 13, new DateTime(1994, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "angela.moore@oexl.com", 3, "Angela", "Female", "/Images/Profile/AngelaMoore.jpg", "Moore", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "EmployeeJobTitles");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
