using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreMeasureUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ProductVariations_MeasureUnit",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ProductVariations_MeasureUnit",
                schema: "dbo",
                table: "ProductVariations",
                sql: "MeasureUnit IN ('g', 'kg', 'l', 'ml', 'und', 'caja', 'cajas', 'lb', 'botella', 'botellas')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ProductVariations_MeasureUnit",
                schema: "dbo",
                table: "ProductVariations");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ProductVariations_MeasureUnit",
                schema: "dbo",
                table: "ProductVariations",
                sql: "MeasureUnit IN ('g', 'kg', 'l', 'ml', 'und', 'caja', 'lb', 'botella')");
        }
    }
}
