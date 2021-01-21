using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class ErrorUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ToTable",
                table: "Games",
                column: "Id_developer",
                principalTable: "Developer",
                principalColumn: "ID_Developer",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games",
                column: "Id_publisher",
                principalTable: "Publisher",
                principalColumn: "ID_Publisher",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ToTable",
                table: "Games",
                column: "Id_developer",
                principalTable: "Developer",
                principalColumn: "ID_Developer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games",
                column: "Id_publisher",
                principalTable: "Publisher",
                principalColumn: "ID_Publisher",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
