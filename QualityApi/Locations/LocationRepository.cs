using Microsoft.EntityFrameworkCore;
using QualityApi.Data;
using LocationEntity = QualityApi.Locations.Entities.Location;

namespace QualityApi.Locations{
    public class LocationRepository : ILocationRepository{
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IEnumerable<LocationEntity>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<LocationEntity> GetLocationByIdAsync(long id){
            return await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<LocationEntity> UpdateLocationAsync(LocationEntity location)
    {
        _context.Entry(location).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LocationExists(location.Id))
            {
                throw new KeyNotFoundException($"Location with ID {location.Id} not found.");
            }
            else
            {
                throw;
            }
        }

        return location;
    }

    private bool LocationExists(long id)
    {
        return _context.Locations.Any(e => e.Id == id);
    }
    }
}