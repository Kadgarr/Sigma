using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class UpdateContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_recording",
                table: "GenresGames",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id_recording",
                table: "Content_of_order",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "Content_of_order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "[PK_GenresGames]",
                table: "GenresGames",
                column: "id_recording");

            migrationBuilder.AddPrimaryKey(
                name: "[PK_Content_of_order]",
                table: "Content_of_order",
                column: "id_recording");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "[PK_GenresGames]",
                table: "GenresGames");

            migrationBuilder.DropPrimaryKey(
                name: "[PK_Content_of_order]",
                table: "Content_of_order");

            migrationBuilder.DropColumn(
                name: "id_recording",
                table: "GenresGames");

            migrationBuilder.DropColumn(
                name: "id_recording",
                table: "Content_of_order");

            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "Content_of_order");
        }
    }
}
