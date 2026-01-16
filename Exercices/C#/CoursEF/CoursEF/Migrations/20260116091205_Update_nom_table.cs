using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursEF.Migrations
{
    /// <inheritdoc />
    public partial class Update_nom_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsDbSet",
                table: "StudentsDbSet");

            migrationBuilder.RenameTable(
                name: "StudentsDbSet",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentsDbSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsDbSet",
                table: "StudentsDbSet",
                column: "Id");
        }
    }
}
