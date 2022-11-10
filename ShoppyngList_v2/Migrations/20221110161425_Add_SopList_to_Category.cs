using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppyngListv2.Migrations
{
    /// <inheritdoc />
    public partial class AddSopListtoCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CategoryShopList",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    ShopListsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryShopList", x => new { x.CategoriesId, x.ShopListsId });
                    table.ForeignKey(
                        name: "FK_CategoryShopList_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryShopList_ShopLists_ShopListsId",
                        column: x => x.ShopListsId,
                        principalTable: "ShopLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryShopList_ShopListsId",
                table: "CategoryShopList",
                column: "ShopListsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryShopList");

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
    }
}
