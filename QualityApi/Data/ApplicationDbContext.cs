using Microsoft.EntityFrameworkCore;
using CaseEntity = QualityApi.Cases.Entities.Case;
using ProductEntity = QualityApi.Product.Entities.Product;
using LocationEntity = QualityApi.Locations.Entities.Location;

namespace QualityApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CaseEntity> Cases { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Locations
            LocationSeeder.SeedLocations(modelBuilder);

            // Product and Case relationship
            modelBuilder.Entity<ProductEntity>()
                .HasMany(p => p.Cases)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);

            // Case and Location relationship
            modelBuilder.Entity<CaseEntity>()
        .HasOne(c => c.Location)
        .WithOne(l => l.Case)
        .HasForeignKey<CaseEntity>(c => c.LocationId)
        .OnDelete(DeleteBehavior.Restrict); // leave this for now and test to see what happens when updating cases/locations

            modelBuilder.Entity<CaseEntity>()
                .Property(e => e.RecoveredCost)
                .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.RetailPrice)
                .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.CostPrice)
                .HasColumnType("decimal(8,2)");

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.UnitWeight)
                .HasColumnType("decimal(8,3)");
        }


        //     protected override void OnModelCreating(ModelBuilder modelBuilder)
        //     {
        //         base.OnModelCreating(modelBuilder);
        //         LocationSeeder.SeedLocations(modelBuilder);
        //         modelBuilder.Entity<ProductEntity>()
        //             .HasMany(p => p.Cases)
        //             .WithOne(c => c.Product)
        //             .HasForeignKey(c => c.ProductId);
        //         // modelBuilder.Entity<CaseEntity>().HasOne(c => c.Location).WithOne(l => l.Case).HasForeignKey(c => c.LocationId); // Todo: implement Location entity relationship
        //         modelBuilder.Entity<CaseEntity>()
        //     .Property(e => e.RecoveredCost)
        //     .HasColumnType("decimal(8,2)");
        //         modelBuilder.Entity<CaseEntity>()
        //   .Property(e => e.Product.RetailPrice)
        //   .HasColumnType("decimal(8,2)");
        //         modelBuilder.Entity<CaseEntity>()
        //        .Property(e => e.Product.CostPrice)
        //        .HasColumnType("decimal(8,2)");
        //         modelBuilder.Entity<CaseEntity>()
        //        .Property(e => e.Product.UnitWeight)
        //        .HasColumnType("decimal(8,3)");
        //         modelBuilder.Entity<ProductEntity>()
        //         .Property(e => e.CostPrice)
        //         .HasColumnType("decimal(8,2)");
        //         modelBuilder.Entity<ProductEntity>()
        //         .Property(e => e.RetailPrice)
        //         .HasColumnType("decimal(8,2)");
        //         modelBuilder.Entity<ProductEntity>()
        //         .Property(e => e.UnitWeight)
        //         .HasColumnType("decimal(8,3)");
        //     }


    }
}