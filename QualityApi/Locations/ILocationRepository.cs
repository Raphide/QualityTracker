using LocationEntity = QualityApi.Locations.Entities.Location;

namespace QualityApi.Locations{
    public interface ILocationRepository{
        Task<LocationEntity> GetLocationByIdAsync(long locationId);
    }
}