using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenresGames_ToTable_1",
                table: "GenresGames");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idCard",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Games",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GenresGames_ToTable_",
                table: "GenresGames",
                column: "Id_game",
                principalTable: "Games",
                principalColumn: "ID_Game",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenresGames_ToTable_",
                table: "GenresGames");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "idCard",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Orders",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Games",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddForeignKey(
                name: "FK_GenresGames_ToTable_1",
                table: "GenresGames",
                column: "Id_game",
                principalTable: "Games",
                principalColumn: "ID_Game",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
