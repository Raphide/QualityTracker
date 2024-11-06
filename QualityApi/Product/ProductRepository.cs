using Microsoft.EntityFrameworkCore;
using QualityApi.Data;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Product{
    public class ProductRepository : IProductRepository{
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context){
            _context = context;
        }
        public async Task<ProductEntity> AddProductAsync(ProductEntity product){
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductEntity> GetProductByIdAsync(long id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}