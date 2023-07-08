using Microsoft.EntityFrameworkCore.Migrations;

namespace Waitrose.Migrations
{
    public partial class AddisDecativeColToSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeactive",
                table: "Sections",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeactive",
                table: "Sections");
        }
    }
}
