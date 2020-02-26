using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.WebUI.Migrations
{
    public partial class sliderColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSlider",
                table: "Blogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSlider",
                table: "Blogs");
        }
    }
}
