using Microsoft.EntityFrameworkCore;
using LocationEntity = QualityApi.Locations.Entities.Location;

public static class LocationSeeder
{
    public static void SeedLocations(ModelBuilder modelBuilder)
    {
        var locations = GenerateLocations();
        modelBuilder.Entity<LocationEntity>().HasData(locations);
    }

    private static List<LocationEntity> GenerateLocations()
    {
        var locations = new List<LocationEntity>();
        int id = 1;

        for (int aisle = 1; aisle <= 5; aisle++)
        {
            for (int shelf = 1; shelf <= 10; shelf++)
            {
                for (int level = 1; level <= 4; level++)
                {
                    var location = new LocationEntity
                    {
                        Id = id++,
                        Shelf = shelf,
                        Level = level,
                        Aisle = aisle,
                        FullLocation = $"{shelf:D2}-{level:D2}-{aisle:D2}",
                        IsOccupied = false,
                        Case = null
                    };

                    locations.Add(location);
                }
            }
        }

        return locations;
    }
}
