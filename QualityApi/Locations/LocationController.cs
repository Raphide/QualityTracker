using Microsoft.AspNetCore.Mvc;

namespace QualityApi.Locations{
    [ApiController]
    [Route("/locations")]
    public class LocationController : ControllerBase{
        private readonly LocationService _locationService;

        public LocationController(LocationService locationService){
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocations(){
            var locations = await _locationService.FindAllLocationsAsync();
            return Ok(locations);
        }
    }
}