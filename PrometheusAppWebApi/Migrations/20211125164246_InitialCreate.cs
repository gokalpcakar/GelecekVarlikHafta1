using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrometheusAppWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "marysmith@gmail.com", "Mary", "5462356564", "Smith" },
                    { 2, new DateTime(1975, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "saralongway@gmail.com", "Sara", "5612356452", "Longway" },
                    { 3, new DateTime(1991, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "johnhastings@gmail.com", "John", "5264589568", "Hastings" },
                    { 4, new DateTime(1988, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "samgalloway@gmail.com", "Sam", "5145362585", "Galloway" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
