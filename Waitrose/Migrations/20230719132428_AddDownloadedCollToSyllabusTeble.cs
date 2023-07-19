using Microsoft.EntityFrameworkCore.Migrations;

namespace Waitrose.Migrations
{
    public partial class AddDownloadedCollToSyllabusTeble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Downloaded",
                table: "Syllabuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Downloaded",
                table: "Syllabuses");
        }
    }
}
