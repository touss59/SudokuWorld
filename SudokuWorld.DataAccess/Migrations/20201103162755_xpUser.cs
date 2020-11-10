using Microsoft.EntityFrameworkCore.Migrations;

namespace SudokuWorld.DataAccess.Migrations
{
    public partial class xpUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XP",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XP",
                table: "AspNetUsers");
        }
    }
}
