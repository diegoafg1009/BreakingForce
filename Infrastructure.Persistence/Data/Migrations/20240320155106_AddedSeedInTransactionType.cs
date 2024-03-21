using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedInTransactionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TransactionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("56626b64-485b-458a-99fb-cdb5b635526e"), "Creation" },
                    { new Guid("922ff6a9-ad99-4b78-8826-fc2136829e53"), "Update" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("56626b64-485b-458a-99fb-cdb5b635526e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("922ff6a9-ad99-4b78-8826-fc2136829e53"));
        }
    }
}
