using LocationEntity = QualityApi.Locations.Entities.Location;

namespace QualityApi.Locations{
    public interface ILocationRepository{
        Task<IEnumerable<LocationEntity>> GetAllLocationsAsync();
        Task<LocationEntity> GetLocationByIdAsync(long locationId);
        Task<LocationEntity> UpdateLocationAsync(LocationEntity location);
    }
}