using LocationEntity = QualityApi.Locations.Entities.Location;

namespace QualityApi.Locations{
    public class LocationService{
        private readonly ILocationRepository _repo;

        public LocationService(ILocationRepository repository){
            _repo = repository;
        }

        public async Task<IEnumerable<LocationEntity>> FindAllLocationsAsync()
        {
            return await _repo.GetAllLocationsAsync();
        }
    }
}