using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Product{
    public interface IProductRepository{
        Task<ProductEntity> AddProductAsync(ProductEntity product);
        Task<ProductEntity> GetProductByIdAsync(long productId);
    }
}