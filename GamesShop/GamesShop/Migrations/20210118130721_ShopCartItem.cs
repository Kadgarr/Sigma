using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class ShopCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopCartId",
                table: "Content_of_order");

            migrationBuilder.CreateTable(
                name: "ShopCartItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gameIdGame = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCartItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopCartItem_Games_gameIdGame",
                        column: x => x.gameIdGame,
                        principalTable: "Games",
                        principalColumn: "ID_Game",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItem_gameIdGame",
                table: "ShopCartItem",
                column: "gameIdGame");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopCartItem");

            migrationBuilder.AddColumn<string>(
                name: "ShopCartId",
                table: "Content_of_order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
