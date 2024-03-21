using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFkToProductVarition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_ProductVariations_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventories_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.DropColumn(
                name: "ProductVariationId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                schema: "dbo",
                table: "ProductVariations",
                newName: "ProductInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_ProductInventoryId",
                schema: "dbo",
                table: "ProductVariations",
                column: "ProductInventoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariations_ProductInventories_ProductInventoryId",
                schema: "dbo",
                table: "ProductVariations",
                column: "ProductInventoryId",
                principalSchema: "dbo",
                principalTable: "ProductInventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariations_ProductInventories_ProductInventoryId",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariations_ProductInventoryId",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.RenameColumn(
                name: "ProductInventoryId",
                schema: "dbo",
                table: "ProductVariations",
                newName: "InventoryId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductVariationId",
                schema: "dbo",
                table: "ProductInventories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories",
                column: "ProductVariationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_ProductVariations_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories",
                column: "ProductVariationId",
                principalSchema: "dbo",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
