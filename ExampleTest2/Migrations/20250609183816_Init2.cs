using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExampleTest2.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FulfilledAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order2s_Client2s_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order2s_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Order", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Product_Order_Order2s_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Order_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client2s",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "FirstName", "LastName" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AcceptedAt", "FulfilledAt" },
                values: new object[] { new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(810), new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(812) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1, "Product", 10m });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Nam" },
                values: new object[] { 1, "Name" });

            migrationBuilder.InsertData(
                table: "Order2s",
                columns: new[] { "Id", "ClientId", "CreatedAt", "FulfilledAt", "StatusId" },
                values: new object[] { 1, 1, new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(628), new DateTime(2025, 6, 9, 20, 38, 15, 714, DateTimeKind.Local).AddTicks(693), 1 });

            migrationBuilder.InsertData(
                table: "Product_Order",
                columns: new[] { "OrderId", "ProductId", "Amount" },
                values: new object[] { 1, 1, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Order2s_ClientId",
                table: "Order2s",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order2s_StatusId",
                table: "Order2s",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Order_ProductId",
                table: "Product_Order",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Order");

            migrationBuilder.DropTable(
                name: "Order2s");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Client2s");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "AcceptedAt", "FulfilledAt" },
                values: new object[] { new DateTime(2025, 6, 9, 17, 14, 23, 748, DateTimeKind.Local).AddTicks(2872), new DateTime(2025, 6, 9, 17, 14, 23, 748, DateTimeKind.Local).AddTicks(2921) });
        }
    }
}
