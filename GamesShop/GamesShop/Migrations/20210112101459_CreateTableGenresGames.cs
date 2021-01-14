using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class CreateTableGenresGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ToTable_2",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_Id_genre",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Id_genre",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Description_of_Game",
                table: "Games",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GenresGames",
                columns: table => new
                {
                    Id_game = table.Column<int>(type: "int", nullable: false),
                    Id_genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GenresGames_ToTable",
                        column: x => x.Id_genre,
                        principalTable: "Genre",
                        principalColumn: "ID_Genre",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GenresGames_ToTable_1",
                        column: x => x.Id_game,
                        principalTable: "Games",
                        principalColumn: "ID_Game",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenresGames_Id_game",
                table: "GenresGames",
                column: "Id_game");

            migrationBuilder.CreateIndex(
                name: "IX_GenresGames_Id_genre",
                table: "GenresGames",
                column: "Id_genre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenresGames");

            migrationBuilder.DropColumn(
                name: "Description_of_Game",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "Id_genre",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Id_genre",
                table: "Games",
                column: "Id_genre");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ToTable_2",
                table: "Games",
                column: "Id_genre",
                principalTable: "Genre",
                principalColumn: "ID_Genre",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
