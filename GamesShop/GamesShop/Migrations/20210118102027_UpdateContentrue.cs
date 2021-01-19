using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class UpdateContentrue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_order",
                table: "Content_of_order",
                newName: "IdOrder");

            migrationBuilder.RenameIndex(
                name: "IX_Content_of_order_Id_order",
                table: "Content_of_order",
                newName: "IX_Content_of_order_IdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdOrder",
                table: "Content_of_order",
                newName: "Id_order");

            migrationBuilder.RenameIndex(
                name: "IX_Content_of_order_IdOrder",
                table: "Content_of_order",
                newName: "IX_Content_of_order_Id_order");
        }
    }
}
