using QualityApi.Cases.DTOs;
using QualityApi.Locations;
using QualityApi.Locations.Entities;
using QualityApi.Product;
using CaseEntity = QualityApi.Cases.Entities.Case;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Cases{
    public class CaseService {
        private readonly ICaseRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly ILocationRepository _locationRepo;
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
           //Todo implement Location Entity 
           var location = await _locationRepo.GetLocationByIdAsync(data.LocationId);
            var cases = new CaseEntity
            {
                CaseNumber = data.CaseNumber,
                ProductId = data.ProductId,
                Product = product,
                Description = data.Description,
                StartDate = data.StartDate,
                Quantity = data.Quantity,
                LocationId = data.LocationId,
                Location = location,
                EndDate = null,
                IsActive = true,
                Outcome = "pending",
                RecoveredCost = 0
            };
            return await _repo.AddCaseAsync(cases);
        }

        internal async Task<IEnumerable<CaseEntity>> FindAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<CaseEntity> FindByIdAsync(long id){
            return await _repo.GetByIdAsync(id);
        }

        // internal async Task<CaseEntity> UpdateCase(long id, UpdateCaseDto data)
        // {
        //     var existingCase = await _repo.GetByIdAsync(id);
        //     if (existingCase == null){
        //         throw new Exception("Case not found");
        //     }

        //     existingCase.Description = data.Description;
        // }
    }
}