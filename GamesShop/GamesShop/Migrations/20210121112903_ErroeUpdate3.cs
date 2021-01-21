using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class ErroeUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "Id_publisher",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id_developer",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "Id_publisher",
                table: "Games",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id_developer",
                table: "Games",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

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
    }
}
