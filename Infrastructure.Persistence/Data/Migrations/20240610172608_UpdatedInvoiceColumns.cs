using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedInvoiceColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReferencePhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AssociatedDocument",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Invoices",
                newName: "Total");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Invoices",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Invoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Invoices",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "IdentificationTypeId",
                table: "Invoices",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Invoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Invoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Ruc",
                table: "Invoices",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Invoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_IdentificationTypeId",
                table: "Invoices",
                column: "IdentificationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_IdentificationTypes_IdentificationTypeId",
                table: "Invoices",
                column: "IdentificationTypeId",
                principalTable: "IdentificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_IdentificationTypes_IdentificationTypeId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_IdentificationTypeId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IdentificationTypeId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Ruc",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Invoices",
                newName: "Amount");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "ReferencePhone",
                table: "Orders",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AssociatedDocument",
                table: "Invoices",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
