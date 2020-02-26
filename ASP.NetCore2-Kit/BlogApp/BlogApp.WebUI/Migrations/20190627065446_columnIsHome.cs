using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.WebUI.Migrations
{
    public partial class columnIsHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isHome",
                table: "Blogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isHome",
                table: "Blogs");
        }
    }
}
