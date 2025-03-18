using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/facilities")]
    [ApiController]
    public class FacilityApiController : ControllerBase
    {
        private readonly IFacilityService _facilityService;

        public FacilityApiController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetFacilitiesByRoomId(int roomId)
        {
            var result = await _facilityService.GetFacilitiesByRoomIdAsync(roomId);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllfacilities()
        {
            var result = await _facilityService.GetFacilities();
            return Ok(result);
        }
    }
}
