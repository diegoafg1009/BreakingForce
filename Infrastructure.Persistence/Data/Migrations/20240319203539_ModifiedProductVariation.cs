using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedProductVariation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                schema: "dbo",
                table: "ProductFlavors",
                newName: "Color");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "dbo",
                table: "ProductBrands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "dbo",
                table: "ProductBrands");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "dbo",
                table: "ProductFlavors",
                newName: "Image");
        }
    }
}
