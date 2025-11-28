using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymLife.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddEgitmenID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "Instructors");

            migrationBuilder.AddColumn<int>(
                name: "EgitmenID",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EgitmenID",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
