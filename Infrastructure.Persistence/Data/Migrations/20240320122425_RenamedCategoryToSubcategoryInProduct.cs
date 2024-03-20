using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCategoryToSubcategoryInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSubcategories_CategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Products",
                newName: "SubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                schema: "dbo",
                table: "Products",
                newName: "IX_Products_SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSubcategories_SubcategoryId",
                schema: "dbo",
                table: "Products",
                column: "SubcategoryId",
                principalSchema: "dbo",
                principalTable: "ProductSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSubcategories_SubcategoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SubcategoryId",
                schema: "dbo",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubcategoryId",
                schema: "dbo",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSubcategories_CategoryId",
                schema: "dbo",
                table: "Products",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "ProductSubcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
