using Microsoft.EntityFrameworkCore.Migrations;

namespace SudokuWorld.DataAccess.Migrations
{
    public partial class difGrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DifficultyId",
                table: "Grids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grids_DifficultyId",
                table: "Grids",
                column: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grids_Difficulties_DifficultyId",
                table: "Grids",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grids_Difficulties_DifficultyId",
                table: "Grids");

            migrationBuilder.DropIndex(
                name: "IX_Grids_DifficultyId",
                table: "Grids");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Grids");
        }
    }
}
