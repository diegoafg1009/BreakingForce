using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryMethodId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                schema: "dbo",
                table: "Orders",
                newName: "PaymentId");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryMethodId",
                schema: "dbo",
                table: "Shipments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentStatusId",
                schema: "dbo",
                table: "Shipments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "ProductVariations",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "PaymentMethods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PaymentStatuses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentStatuses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    PaymentStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "dbo",
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentStatuses_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalSchema: "dbo",
                        principalTable: "PaymentStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "OrderStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("474fb0e1-115d-44d4-9ae0-ba6dec7934da"), "Entregado" },
                    { new Guid("52c7c858-ead7-42a0-9400-15f96e7e920c"), "Confirmado" },
                    { new Guid("52ec1a9e-9711-45c4-b824-8ec28b453cb3"), "En confirmación" },
                    { new Guid("986a5551-b1d4-442c-9bf4-5f2ee360f4e2"), "Ent tránsito" },
                    { new Guid("e25ebe6b-be50-4d22-805a-44377b4de8ae"), "Cancelado" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "PaymentStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("66ee5519-0d6d-4893-b919-8e68a827241c"), "Rechazado" },
                    { new Guid("6f17b493-4bdc-4c70-bbeb-f024d2e23600"), "Pendiente" },
                    { new Guid("a6917b23-590d-49f4-a7e1-780ea9f04f23"), "Cancelado" },
                    { new Guid("aeb99f15-1a49-4b77-b3ed-7958b9577ea9"), "Aprobado" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ShipmentStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b2e81c3-32aa-439e-8514-7f7930c66154"), "Cancelado" },
                    { new Guid("53869e29-d69e-4f5d-bfdb-d0872736dd50"), "En tránsito" },
                    { new Guid("896ac5dc-5ee5-42ba-be53-4bc0e36ed2d6"), "En preparación" },
                    { new Guid("93319dc2-70c9-4621-aa11-6c6c70401f4f"), "Listo para recoger" },
                    { new Guid("ddd08961-05e0-4662-aa10-f3c9e416be03"), "Entregado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_DeliveryMethodId",
                schema: "dbo",
                table: "Shipments",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ShipmentStatusId",
                schema: "dbo",
                table: "Shipments",
                column: "ShipmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                schema: "dbo",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                schema: "dbo",
                table: "Payments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStatusId",
                schema: "dbo",
                table: "Payments",
                column: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_DeliveryMethods_DeliveryMethodId",
                schema: "dbo",
                table: "Shipments",
                column: "DeliveryMethodId",
                principalSchema: "dbo",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_ShipmentStatuses_ShipmentStatusId",
                schema: "dbo",
                table: "Shipments",
                column: "ShipmentStatusId",
                principalSchema: "dbo",
                principalTable: "ShipmentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_DeliveryMethods_DeliveryMethodId",
                schema: "dbo",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_ShipmentStatuses_ShipmentStatusId",
                schema: "dbo",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShipmentStatuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentStatuses",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_DeliveryMethodId",
                schema: "dbo",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ShipmentStatusId",
                schema: "dbo",
                table: "Shipments");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("474fb0e1-115d-44d4-9ae0-ba6dec7934da"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("52c7c858-ead7-42a0-9400-15f96e7e920c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("52ec1a9e-9711-45c4-b824-8ec28b453cb3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("986a5551-b1d4-442c-9bf4-5f2ee360f4e2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: new Guid("e25ebe6b-be50-4d22-805a-44377b4de8ae"));

            migrationBuilder.DropColumn(
                name: "DeliveryMethodId",
                schema: "dbo",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ShipmentStatusId",
                schema: "dbo",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "dbo",
                table: "PaymentMethods");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                schema: "dbo",
                table: "Orders",
                newName: "PaymentMethodId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "ProductVariations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryMethodId",
                schema: "dbo",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryMethodId",
                schema: "dbo",
                table: "Orders",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                schema: "dbo",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                schema: "dbo",
                table: "Orders",
                column: "DeliveryMethodId",
                principalSchema: "dbo",
                principalTable: "DeliveryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                schema: "dbo",
                table: "Orders",
                column: "PaymentMethodId",
                principalSchema: "dbo",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
