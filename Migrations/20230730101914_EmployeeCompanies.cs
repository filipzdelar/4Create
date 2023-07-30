using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Create.Migrations
{
    public partial class EmployeeCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "ResourceAttributes",
                table: "SystemLogs",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceAttributes",
                table: "SystemLogs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Title",
                table: "Companies",
                type: "int",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);
        }
    }
}
