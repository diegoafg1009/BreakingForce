using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMeasureUnitToVariations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeasureUnit",
                schema: "dbo",
                table: "ProductVariations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "kg");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ProductVariations_MeasureUnit",
                schema: "dbo",
                table: "ProductVariations",
                sql: "MeasureUnit IN ('g', 'kg', 'l', 'ml', 'und', 'caja', 'lb', 'botella')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ProductVariations_MeasureUnit",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.DropColumn(
                name: "MeasureUnit",
                schema: "dbo",
                table: "ProductVariations");
        }
    }
}
