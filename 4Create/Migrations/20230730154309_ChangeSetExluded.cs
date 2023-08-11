using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Create.Migrations
{
    public partial class ChangeSetExluded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Changeset",
                table: "SystemLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Changeset",
                table: "SystemLogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
