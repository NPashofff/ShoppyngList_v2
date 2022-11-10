using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppyngListv2.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesToShopList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopListId",
                table: "Categories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShopListId",
                table: "Categories",
                column: "ShopListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ShopLists_ShopListId",
                table: "Categories",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ShopLists_ShopListId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShopListId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShopListId",
                table: "Categories");
        }
    }
}
