using QualityApi.Cases.DTOs;
using QualityApi.Locations;
using QualityApi.Locations.Entities;
using QualityApi.Product;
using CaseEntity = QualityApi.Cases.Entities.Case;
using ProductEntity = QualityApi.Product.Entities.Product;

namespace QualityApi.Cases
{
    public class CaseService
    {
        private readonly ICaseRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly ILocationRepository _locationRepo;
        public CaseService(ICaseRepository repository, IProductRepository productRepository, ILocationRepository locationRepository)
        {
            _repo = repository;
            _productRepo = productRepository;
            _locationRepo = locationRepository;
        }
        public async Task<CaseEntity> CreateCaseAsync(CreateCaseDto data)
        {
            var product = await _productRepo.GetProductByIdAsync(data.ProductId);
            if (product == null)
            {
                throw new Exception($"Product with ID {data.ProductId} not found.");
            }

            var location = await _locationRepo.GetLocationByIdAsync(data.LocationId);
            if (location == null)
            {
                throw new Exception($"Location with ID {data.LocationId} not found.");
            }

            if (location.IsOccupied)
            {
                throw new Exception($"Location with ID {data.LocationId} is already occupied.");
            }

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

            location.IsOccupied = true;
            location.CaseId = cases.Id;

            await _locationRepo.UpdateLocationAsync(location);
            return await _repo.AddCaseAsync(cases);
        }

        internal async Task<IEnumerable<CaseEntity>> FindAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<CaseEntity> FindByIdAsync(long id)
        {
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