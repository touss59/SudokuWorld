using Microsoft.EntityFrameworkCore.Migrations;

namespace SudokuWorld.DataAccess.Migrations
{
    public partial class DifficultyLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Difficulties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Difficulties");
        }
    }
}
