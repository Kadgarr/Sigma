using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesShop.Migrations
{
    public partial class CascadeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Id_game",
                table: "Feedback",
                column: "Id_game");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_ToTable_1",
                table: "Feedback",
                column: "Id_game",
                principalTable: "Games",
                principalColumn: "ID_Game",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_ToTable_1",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_Id_game",
                table: "Feedback");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
