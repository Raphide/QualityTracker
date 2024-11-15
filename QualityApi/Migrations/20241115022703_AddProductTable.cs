using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QualityApi.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CostPrice", "Department", "Name", "RetailPrice", "SKU", "UnitWeight" },
                values: new object[,]
                {
                    { 1L, 800.00m, "Electronics", "Laptop", 1200.00m, "TECH001", 2.5m },
                    { 2L, 400.00m, "Electronics", "Smartphone", 699.99m, "TECH002", 0.2m },
                    { 3L, 50.00m, "Home Appliances", "Coffee Maker", 89.99m, "HOME001", 3.0m },
                    { 4L, 40.00m, "Sports", "Running Shoes", 79.99m, "SPORT001", 0.3m },
                    { 5L, 300.00m, "Electronics", "LED TV", 499.99m, "TECH003", 15.0m },
                    { 6L, 30.00m, "Home Appliances", "Blender", 59.99m, "HOME002", 2.0m },
                    { 7L, 15.00m, "Sports", "Yoga Mat", 29.99m, "SPORT002", 0.5m },
                    { 8L, 50.00m, "Electronics", "Wireless Earbuds", 99.99m, "TECH004", 0.05m },
                    { 9L, 40.00m, "Home Appliances", "Toaster Oven", 69.99m, "HOME003", 4.0m },
                    { 10L, 60.00m, "Sports", "Dumbbell Set", 119.99m, "SPORT003", 10.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10L);
        }
    }
}
