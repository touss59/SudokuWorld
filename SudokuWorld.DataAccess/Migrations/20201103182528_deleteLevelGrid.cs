using Microsoft.EntityFrameworkCore.Migrations;

namespace SudokuWorld.DataAccess.Migrations
{
    public partial class deleteLevelGrid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grids_Difficulties_DifficultyId",
                table: "Grids");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Grids");

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyId",
                table: "Grids",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Grids_Difficulties_DifficultyId",
                table: "Grids",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grids_Difficulties_DifficultyId",
                table: "Grids");

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyId",
                table: "Grids",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Grids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Grids_Difficulties_DifficultyId",
                table: "Grids",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
