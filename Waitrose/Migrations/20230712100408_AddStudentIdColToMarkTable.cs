using Microsoft.EntityFrameworkCore.Migrations;

namespace Waitrose.Migrations
{
    public partial class AddStudentIdColToMarkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Classes_ClassId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Marks",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_ClassId",
                table: "Marks",
                newName: "IX_Marks_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Students_StudentId",
                table: "Marks");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Marks",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Marks_StudentId",
                table: "Marks",
                newName: "IX_Marks_ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Classes_ClassId",
                table: "Marks",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
