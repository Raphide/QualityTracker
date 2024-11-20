using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QualityApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Shelf = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Aisle = table.Column<int>(type: "integer", nullable: false),
                    FullLocation = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    IsOccupied = table.Column<bool>(type: "boolean", nullable: false),
                    CaseId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SKU = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    UnitWeight = table.Column<decimal>(type: "numeric(8,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CaseNumber = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Outcome = table.Column<string>(type: "text", nullable: true),
                    RecoveredCost = table.Column<decimal>(type: "numeric(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cases_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cases_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "Aisle", "CaseId", "FullLocation", "IsOccupied", "Level", "Shelf" },
                values: new object[,]
                {
                    { 1L, 1, null, "01-01-01", false, 1, 1 },
                    { 2L, 1, null, "01-02-01", false, 2, 1 },
                    { 3L, 1, null, "01-03-01", false, 3, 1 },
                    { 4L, 1, null, "01-04-01", false, 4, 1 },
                    { 5L, 1, null, "02-01-01", false, 1, 2 },
                    { 6L, 1, null, "02-02-01", false, 2, 2 },
                    { 7L, 1, null, "02-03-01", false, 3, 2 },
                    { 8L, 1, null, "02-04-01", false, 4, 2 },
                    { 9L, 1, null, "03-01-01", false, 1, 3 },
                    { 10L, 1, null, "03-02-01", false, 2, 3 },
                    { 11L, 1, null, "03-03-01", false, 3, 3 },
                    { 12L, 1, null, "03-04-01", false, 4, 3 },
                    { 13L, 1, null, "04-01-01", false, 1, 4 },
                    { 14L, 1, null, "04-02-01", false, 2, 4 },
                    { 15L, 1, null, "04-03-01", false, 3, 4 },
                    { 16L, 1, null, "04-04-01", false, 4, 4 },
                    { 17L, 1, null, "05-01-01", false, 1, 5 },
                    { 18L, 1, null, "05-02-01", false, 2, 5 },
                    { 19L, 1, null, "05-03-01", false, 3, 5 },
                    { 20L, 1, null, "05-04-01", false, 4, 5 },
                    { 21L, 1, null, "06-01-01", false, 1, 6 },
                    { 22L, 1, null, "06-02-01", false, 2, 6 },
                    { 23L, 1, null, "06-03-01", false, 3, 6 },
                    { 24L, 1, null, "06-04-01", false, 4, 6 },
                    { 25L, 1, null, "07-01-01", false, 1, 7 },
                    { 26L, 1, null, "07-02-01", false, 2, 7 },
                    { 27L, 1, null, "07-03-01", false, 3, 7 },
                    { 28L, 1, null, "07-04-01", false, 4, 7 },
                    { 29L, 1, null, "08-01-01", false, 1, 8 },
                    { 30L, 1, null, "08-02-01", false, 2, 8 },
                    { 31L, 1, null, "08-03-01", false, 3, 8 },
                    { 32L, 1, null, "08-04-01", false, 4, 8 },
                    { 33L, 1, null, "09-01-01", false, 1, 9 },
                    { 34L, 1, null, "09-02-01", false, 2, 9 },
                    { 35L, 1, null, "09-03-01", false, 3, 9 },
                    { 36L, 1, null, "09-04-01", false, 4, 9 },
                    { 37L, 1, null, "10-01-01", false, 1, 10 },
                    { 38L, 1, null, "10-02-01", false, 2, 10 },
                    { 39L, 1, null, "10-03-01", false, 3, 10 },
                    { 40L, 1, null, "10-04-01", false, 4, 10 },
                    { 41L, 2, null, "01-01-02", false, 1, 1 },
                    { 42L, 2, null, "01-02-02", false, 2, 1 },
                    { 43L, 2, null, "01-03-02", false, 3, 1 },
                    { 44L, 2, null, "01-04-02", false, 4, 1 },
                    { 45L, 2, null, "02-01-02", false, 1, 2 },
                    { 46L, 2, null, "02-02-02", false, 2, 2 },
                    { 47L, 2, null, "02-03-02", false, 3, 2 },
                    { 48L, 2, null, "02-04-02", false, 4, 2 },
                    { 49L, 2, null, "03-01-02", false, 1, 3 },
                    { 50L, 2, null, "03-02-02", false, 2, 3 },
                    { 51L, 2, null, "03-03-02", false, 3, 3 },
                    { 52L, 2, null, "03-04-02", false, 4, 3 },
                    { 53L, 2, null, "04-01-02", false, 1, 4 },
                    { 54L, 2, null, "04-02-02", false, 2, 4 },
                    { 55L, 2, null, "04-03-02", false, 3, 4 },
                    { 56L, 2, null, "04-04-02", false, 4, 4 },
                    { 57L, 2, null, "05-01-02", false, 1, 5 },
                    { 58L, 2, null, "05-02-02", false, 2, 5 },
                    { 59L, 2, null, "05-03-02", false, 3, 5 },
                    { 60L, 2, null, "05-04-02", false, 4, 5 },
                    { 61L, 2, null, "06-01-02", false, 1, 6 },
                    { 62L, 2, null, "06-02-02", false, 2, 6 },
                    { 63L, 2, null, "06-03-02", false, 3, 6 },
                    { 64L, 2, null, "06-04-02", false, 4, 6 },
                    { 65L, 2, null, "07-01-02", false, 1, 7 },
                    { 66L, 2, null, "07-02-02", false, 2, 7 },
                    { 67L, 2, null, "07-03-02", false, 3, 7 },
                    { 68L, 2, null, "07-04-02", false, 4, 7 },
                    { 69L, 2, null, "08-01-02", false, 1, 8 },
                    { 70L, 2, null, "08-02-02", false, 2, 8 },
                    { 71L, 2, null, "08-03-02", false, 3, 8 },
                    { 72L, 2, null, "08-04-02", false, 4, 8 },
                    { 73L, 2, null, "09-01-02", false, 1, 9 },
                    { 74L, 2, null, "09-02-02", false, 2, 9 },
                    { 75L, 2, null, "09-03-02", false, 3, 9 },
                    { 76L, 2, null, "09-04-02", false, 4, 9 },
                    { 77L, 2, null, "10-01-02", false, 1, 10 },
                    { 78L, 2, null, "10-02-02", false, 2, 10 },
                    { 79L, 2, null, "10-03-02", false, 3, 10 },
                    { 80L, 2, null, "10-04-02", false, 4, 10 },
                    { 81L, 3, null, "01-01-03", false, 1, 1 },
                    { 82L, 3, null, "01-02-03", false, 2, 1 },
                    { 83L, 3, null, "01-03-03", false, 3, 1 },
                    { 84L, 3, null, "01-04-03", false, 4, 1 },
                    { 85L, 3, null, "02-01-03", false, 1, 2 },
                    { 86L, 3, null, "02-02-03", false, 2, 2 },
                    { 87L, 3, null, "02-03-03", false, 3, 2 },
                    { 88L, 3, null, "02-04-03", false, 4, 2 },
                    { 89L, 3, null, "03-01-03", false, 1, 3 },
                    { 90L, 3, null, "03-02-03", false, 2, 3 },
                    { 91L, 3, null, "03-03-03", false, 3, 3 },
                    { 92L, 3, null, "03-04-03", false, 4, 3 },
                    { 93L, 3, null, "04-01-03", false, 1, 4 },
                    { 94L, 3, null, "04-02-03", false, 2, 4 },
                    { 95L, 3, null, "04-03-03", false, 3, 4 },
                    { 96L, 3, null, "04-04-03", false, 4, 4 },
                    { 97L, 3, null, "05-01-03", false, 1, 5 },
                    { 98L, 3, null, "05-02-03", false, 2, 5 },
                    { 99L, 3, null, "05-03-03", false, 3, 5 },
                    { 100L, 3, null, "05-04-03", false, 4, 5 },
                    { 101L, 3, null, "06-01-03", false, 1, 6 },
                    { 102L, 3, null, "06-02-03", false, 2, 6 },
                    { 103L, 3, null, "06-03-03", false, 3, 6 },
                    { 104L, 3, null, "06-04-03", false, 4, 6 },
                    { 105L, 3, null, "07-01-03", false, 1, 7 },
                    { 106L, 3, null, "07-02-03", false, 2, 7 },
                    { 107L, 3, null, "07-03-03", false, 3, 7 },
                    { 108L, 3, null, "07-04-03", false, 4, 7 },
                    { 109L, 3, null, "08-01-03", false, 1, 8 },
                    { 110L, 3, null, "08-02-03", false, 2, 8 },
                    { 111L, 3, null, "08-03-03", false, 3, 8 },
                    { 112L, 3, null, "08-04-03", false, 4, 8 },
                    { 113L, 3, null, "09-01-03", false, 1, 9 },
                    { 114L, 3, null, "09-02-03", false, 2, 9 },
                    { 115L, 3, null, "09-03-03", false, 3, 9 },
                    { 116L, 3, null, "09-04-03", false, 4, 9 },
                    { 117L, 3, null, "10-01-03", false, 1, 10 },
                    { 118L, 3, null, "10-02-03", false, 2, 10 },
                    { 119L, 3, null, "10-03-03", false, 3, 10 },
                    { 120L, 3, null, "10-04-03", false, 4, 10 },
                    { 121L, 4, null, "01-01-04", false, 1, 1 },
                    { 122L, 4, null, "01-02-04", false, 2, 1 },
                    { 123L, 4, null, "01-03-04", false, 3, 1 },
                    { 124L, 4, null, "01-04-04", false, 4, 1 },
                    { 125L, 4, null, "02-01-04", false, 1, 2 },
                    { 126L, 4, null, "02-02-04", false, 2, 2 },
                    { 127L, 4, null, "02-03-04", false, 3, 2 },
                    { 128L, 4, null, "02-04-04", false, 4, 2 },
                    { 129L, 4, null, "03-01-04", false, 1, 3 },
                    { 130L, 4, null, "03-02-04", false, 2, 3 },
                    { 131L, 4, null, "03-03-04", false, 3, 3 },
                    { 132L, 4, null, "03-04-04", false, 4, 3 },
                    { 133L, 4, null, "04-01-04", false, 1, 4 },
                    { 134L, 4, null, "04-02-04", false, 2, 4 },
                    { 135L, 4, null, "04-03-04", false, 3, 4 },
                    { 136L, 4, null, "04-04-04", false, 4, 4 },
                    { 137L, 4, null, "05-01-04", false, 1, 5 },
                    { 138L, 4, null, "05-02-04", false, 2, 5 },
                    { 139L, 4, null, "05-03-04", false, 3, 5 },
                    { 140L, 4, null, "05-04-04", false, 4, 5 },
                    { 141L, 4, null, "06-01-04", false, 1, 6 },
                    { 142L, 4, null, "06-02-04", false, 2, 6 },
                    { 143L, 4, null, "06-03-04", false, 3, 6 },
                    { 144L, 4, null, "06-04-04", false, 4, 6 },
                    { 145L, 4, null, "07-01-04", false, 1, 7 },
                    { 146L, 4, null, "07-02-04", false, 2, 7 },
                    { 147L, 4, null, "07-03-04", false, 3, 7 },
                    { 148L, 4, null, "07-04-04", false, 4, 7 },
                    { 149L, 4, null, "08-01-04", false, 1, 8 },
                    { 150L, 4, null, "08-02-04", false, 2, 8 },
                    { 151L, 4, null, "08-03-04", false, 3, 8 },
                    { 152L, 4, null, "08-04-04", false, 4, 8 },
                    { 153L, 4, null, "09-01-04", false, 1, 9 },
                    { 154L, 4, null, "09-02-04", false, 2, 9 },
                    { 155L, 4, null, "09-03-04", false, 3, 9 },
                    { 156L, 4, null, "09-04-04", false, 4, 9 },
                    { 157L, 4, null, "10-01-04", false, 1, 10 },
                    { 158L, 4, null, "10-02-04", false, 2, 10 },
                    { 159L, 4, null, "10-03-04", false, 3, 10 },
                    { 160L, 4, null, "10-04-04", false, 4, 10 },
                    { 161L, 5, null, "01-01-05", false, 1, 1 },
                    { 162L, 5, null, "01-02-05", false, 2, 1 },
                    { 163L, 5, null, "01-03-05", false, 3, 1 },
                    { 164L, 5, null, "01-04-05", false, 4, 1 },
                    { 165L, 5, null, "02-01-05", false, 1, 2 },
                    { 166L, 5, null, "02-02-05", false, 2, 2 },
                    { 167L, 5, null, "02-03-05", false, 3, 2 },
                    { 168L, 5, null, "02-04-05", false, 4, 2 },
                    { 169L, 5, null, "03-01-05", false, 1, 3 },
                    { 170L, 5, null, "03-02-05", false, 2, 3 },
                    { 171L, 5, null, "03-03-05", false, 3, 3 },
                    { 172L, 5, null, "03-04-05", false, 4, 3 },
                    { 173L, 5, null, "04-01-05", false, 1, 4 },
                    { 174L, 5, null, "04-02-05", false, 2, 4 },
                    { 175L, 5, null, "04-03-05", false, 3, 4 },
                    { 176L, 5, null, "04-04-05", false, 4, 4 },
                    { 177L, 5, null, "05-01-05", false, 1, 5 },
                    { 178L, 5, null, "05-02-05", false, 2, 5 },
                    { 179L, 5, null, "05-03-05", false, 3, 5 },
                    { 180L, 5, null, "05-04-05", false, 4, 5 },
                    { 181L, 5, null, "06-01-05", false, 1, 6 },
                    { 182L, 5, null, "06-02-05", false, 2, 6 },
                    { 183L, 5, null, "06-03-05", false, 3, 6 },
                    { 184L, 5, null, "06-04-05", false, 4, 6 },
                    { 185L, 5, null, "07-01-05", false, 1, 7 },
                    { 186L, 5, null, "07-02-05", false, 2, 7 },
                    { 187L, 5, null, "07-03-05", false, 3, 7 },
                    { 188L, 5, null, "07-04-05", false, 4, 7 },
                    { 189L, 5, null, "08-01-05", false, 1, 8 },
                    { 190L, 5, null, "08-02-05", false, 2, 8 },
                    { 191L, 5, null, "08-03-05", false, 3, 8 },
                    { 192L, 5, null, "08-04-05", false, 4, 8 },
                    { 193L, 5, null, "09-01-05", false, 1, 9 },
                    { 194L, 5, null, "09-02-05", false, 2, 9 },
                    { 195L, 5, null, "09-03-05", false, 3, 9 },
                    { 196L, 5, null, "09-04-05", false, 4, 9 },
                    { 197L, 5, null, "10-01-05", false, 1, 10 },
                    { 198L, 5, null, "10-02-05", false, 2, 10 },
                    { 199L, 5, null, "10-03-05", false, 3, 10 },
                    { 200L, 5, null, "10-04-05", false, 4, 10 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_cases_LocationId",
                table: "cases",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cases_ProductId",
                table: "cases",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cases");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
