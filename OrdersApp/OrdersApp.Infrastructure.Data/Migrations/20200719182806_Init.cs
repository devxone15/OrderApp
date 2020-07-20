using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdersApp.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreateDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2017, 10, 20, 1, 10, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2017, 1, 10, 5, 30, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Product #1", 100m },
                    { 2, "Product #2", 10m },
                    { 3, "Product #3", 5m },
                    { 4, "Product #4", 10m }
                });

            migrationBuilder.InsertData(
                table: "ProductsInOrders",
                columns: new[] { "Id", "OrderId", "ProductCount", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 5, 2 },
                    { 3, 2, 1, 3 },
                    { 4, 2, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInOrders_OrderId",
                table: "ProductsInOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInOrders_ProductId",
                table: "ProductsInOrders",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsInOrders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
