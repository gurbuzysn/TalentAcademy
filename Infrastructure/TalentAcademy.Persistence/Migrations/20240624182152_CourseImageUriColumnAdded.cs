using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentAcademy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CourseImageUriColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "Courses");
        }
    }
}
