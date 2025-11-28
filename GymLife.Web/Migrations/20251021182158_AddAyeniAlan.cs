using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymLife.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddAyeniAlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResimURL",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResimURL",
                table: "Branches");
        }
    }
}
