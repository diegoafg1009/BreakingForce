using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FlaverNotRequiredAnymoreInProductVariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariations_ProductFlavors_FlavorId",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "dbo",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FlavorId",
                schema: "dbo",
                table: "ProductVariations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariations_ProductFlavors_FlavorId",
                schema: "dbo",
                table: "ProductVariations",
                column: "FlavorId",
                principalSchema: "dbo",
                principalTable: "ProductFlavors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariations_ProductFlavors_FlavorId",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "dbo",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "FlavorId",
                schema: "dbo",
                table: "ProductVariations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariations_ProductFlavors_FlavorId",
                schema: "dbo",
                table: "ProductVariations",
                column: "FlavorId",
                principalSchema: "dbo",
                principalTable: "ProductFlavors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
