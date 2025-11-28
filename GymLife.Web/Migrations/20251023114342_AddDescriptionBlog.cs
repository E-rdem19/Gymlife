using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymLife.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");
        }
    }
}
