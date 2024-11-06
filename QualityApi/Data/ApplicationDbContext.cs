using Microsoft.EntityFrameworkCore;
using CaseEntity = QualityApi.Cases.Entities.Case;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Data{
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}
        public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CaseEntity> Cases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
            .HasMany(p => p.Cases)
            .WithOne(c => c.Product)
            .HasForeignKey(c => c.ProductId);
    }
    }
}