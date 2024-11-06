using QualityApi.Cases.DTOs;
using QualityApi.Product;
using CaseEntity = QualityApi.Cases.Entities.Case;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Cases{
    public class CaseService {
        private readonly ICaseRepository _repo;
        private readonly IProductRepository _productRepo;
        public CaseService(ICaseRepository repository, IProductRepository productRepository){
            _repo = repository;
            _productRepo = productRepository;
            
        }
        public async Task<CaseEntity> CreateCaseAsync(CreateCaseDto data){
             var product = await _productRepo.GetProductByIdAsync(data.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with ID {data.ProductId} not found.");
            }
            var cases = new CaseEntity
            {
                CaseNumber = data.CaseNumber,
                ProductId = data.ProductId,
                Product = product,
                Description = data.Description,
                StartDate = data.StartDate,
                Quantity = data.Quantity,
                EndDate = null,
                IsActive = true,
                Outcome = "pending",
                RecoveredCost = 0
            };
            return await _repo.AddCaseAsync(cases);
        }
    }
}