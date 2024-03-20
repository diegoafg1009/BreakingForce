using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductVariationsAndFlavors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "dbo",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_Products_Id",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "dbo",
                table: "OrderDetails",
                newName: "ProductVariationId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductId",
                schema: "dbo",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductVariationId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductVariationId",
                schema: "dbo",
                table: "ProductInventories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "dbo",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "ProductFlavors",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFlavors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlavorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariations_ProductFlavors_FlavorId",
                        column: x => x.FlavorId,
                        principalSchema: "dbo",
                        principalTable: "ProductFlavors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariations_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventories_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories",
                column: "ProductVariationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_FlavorId",
                schema: "dbo",
                table: "ProductVariations",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_ProductId",
                schema: "dbo",
                table: "ProductVariations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductVariations_ProductVariationId",
                schema: "dbo",
                table: "OrderDetails",
                column: "ProductVariationId",
                principalSchema: "dbo",
                principalTable: "ProductVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductVariations_ProductVariationId",
                schema: "dbo",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventories_ProductVariations_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.DropTable(
                name: "ProductVariations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductFlavors",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventories_ProductVariationId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.DropColumn(
                name: "ProductVariationId",
                schema: "dbo",
                table: "ProductInventories");

            migrationBuilder.RenameColumn(
                name: "ProductVariationId",
                schema: "dbo",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ProductVariationId",
                schema: "dbo",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryId",
                schema: "dbo",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                schema: "dbo",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "dbo",
                table: "ProductInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                schema: "dbo",
                table: "ProductImages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                schema: "dbo",
                table: "OrderDetails",
                column: "ProductId",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventories_Products_Id",
                schema: "dbo",
                table: "ProductInventories",
                column: "Id",
                principalSchema: "dbo",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
