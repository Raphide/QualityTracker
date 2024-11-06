using QualityApi.Product.DTOs;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Product{
    public class ProductService{

        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repository){
            _repo = repository;
        }
        public async Task<ProductEntity> CreateProductAsync(CreateProductDto data){
            var product = new ProductEntity{
                Name = data.Name,
                SKU = data.SKU,
                Department = data.Department,
                CostPrice = data.CostPrice,
                RetailPrice = data.RetailPrice,
                UnitWeight = data.UnitWeight
            };
            return await _repo.AddProductAsync(product);
        }
    }
}