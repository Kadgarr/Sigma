using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class Error4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable_1",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazi_ToTable",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id_game",
                table: "GenresGames",
                newName: "IdGame");

            migrationBuilder.RenameIndex(
                name: "IX_GenresGames_Id_game",
                table: "GenresGames",
                newName: "IX_GenresGames_IdGame");

            migrationBuilder.AlterColumn<int>(
                name: "Id_genre",
                table: "GenresGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdGame",
                table: "GenresGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GamesIdGame",
                table: "GenresGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenresGames_GamesIdGame",
                table: "GenresGames",
                column: "GamesIdGame");

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

            migrationBuilder.AddForeignKey(
                name: "FK_GenresGames_Games_GamesIdGame",
                table: "GenresGames",
                column: "GamesIdGame",
                principalTable: "Games",
                principalColumn: "ID_Game",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazi_ToTable",
                table: "Orders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "ID_Pokupatel",
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

            migrationBuilder.DropForeignKey(
                name: "FK_GenresGames_Games_GamesIdGame",
                table: "GenresGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Zakazi_ToTable",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_GenresGames_GamesIdGame",
                table: "GenresGames");

            migrationBuilder.DropColumn(
                name: "GamesIdGame",
                table: "GenresGames");

            migrationBuilder.RenameColumn(
                name: "IdGame",
                table: "GenresGames",
                newName: "Id_game");

            migrationBuilder.RenameIndex(
                name: "IX_GenresGames_IdGame",
                table: "GenresGames",
                newName: "IX_GenresGames_Id_game");

            migrationBuilder.AlterColumn<int>(
                name: "Id_genre",
                table: "GenresGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_game",
                table: "GenresGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Zakazi_ToTable",
                table: "Orders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "ID_Pokupatel",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
