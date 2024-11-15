using ProductEntity = QualityApi.Product.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace QualityApi.Data
{
    public static class ProductSeeder
    {
        public static void SeedProducts(ModelBuilder modelBuilder)
        {
            var products = new List<ProductEntity>
            {
                new() { Id = 1, Name = "Laptop", SKU = "TECH001", Department = "Electronics", CostPrice = 800.00m, RetailPrice = 1200.00m, UnitWeight = 2.5m },
                new() { Id = 2, Name = "Smartphone", SKU = "TECH002", Department = "Electronics", CostPrice = 400.00m, RetailPrice = 699.99m, UnitWeight = 0.2m },
                new() { Id = 3, Name = "Coffee Maker", SKU = "HOME001", Department = "Home Appliances", CostPrice = 50.00m, RetailPrice = 89.99m, UnitWeight = 3.0m },
                new() { Id = 4, Name = "Running Shoes", SKU = "SPORT001", Department = "Sports", CostPrice = 40.00m, RetailPrice = 79.99m, UnitWeight = 0.3m },
                new() { Id = 5, Name = "LED TV", SKU = "TECH003", Department = "Electronics", CostPrice = 300.00m, RetailPrice = 499.99m, UnitWeight = 15.0m },
                new() { Id = 6, Name = "Blender", SKU = "HOME002", Department = "Home Appliances", CostPrice = 30.00m, RetailPrice = 59.99m, UnitWeight = 2.0m },
                new() { Id = 7, Name = "Yoga Mat", SKU = "SPORT002", Department = "Sports", CostPrice = 15.00m, RetailPrice = 29.99m, UnitWeight = 0.5m },
                new() { Id = 8, Name = "Wireless Earbuds", SKU = "TECH004", Department = "Electronics", CostPrice = 50.00m, RetailPrice = 99.99m, UnitWeight = 0.05m },
                new() { Id = 9, Name = "Toaster Oven", SKU = "HOME003", Department = "Home Appliances", CostPrice = 40.00m, RetailPrice = 69.99m, UnitWeight = 4.0m },
                new() { Id = 10, Name = "Dumbbell Set", SKU = "SPORT003", Department = "Sports", CostPrice = 60.00m, RetailPrice = 119.99m, UnitWeight = 10.0m }
            };

            modelBuilder.Entity<ProductEntity>().HasData(products);
        }
    }
}
