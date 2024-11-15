using Microsoft.EntityFrameworkCore;
using QualityApi.Data;
using LocationEntity = QualityApi.Locations.Entities.Location;

namespace QualityApi.Locations{
    public class LocationRepository : ILocationRepository{
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task<LocationEntity> GetLocationByIdAsync(long id){
            return await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}