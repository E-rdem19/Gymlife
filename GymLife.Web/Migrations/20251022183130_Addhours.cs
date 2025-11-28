using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymLife.Web.Migrations
{
    /// <inheritdoc />
    public partial class Addhours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Course_Programs",
                newName: "Time");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Course_Programs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Course_Programs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Course_Programs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Course_Programs");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Course_Programs",
                newName: "Duration");
        }
    }
}
