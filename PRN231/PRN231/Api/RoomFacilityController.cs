using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231.Entities;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/room-facility")]
    [ApiController]
    public class RoomFacilityController : ControllerBase
    {
        private readonly IRoomFacilityService _roomFacilityService;

        public RoomFacilityController(IRoomFacilityService roomFacilityService)
        {
            _roomFacilityService = roomFacilityService;
        }

        [HttpGet]
        public async Task<ActionResult> GetRoomFacilities()
        {
            var res = await _roomFacilityService.GetRoomFacilities();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomFacility>> GetRoomFacility(int id)
        {
            var roomFacility = await _roomFacilityService.GetRoomFacility(id);
            return Ok(roomFacility);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoomFacility(RoomFacility roomFacility)
        {
            await _roomFacilityService.AddRoomFacility(roomFacility);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoomFacility(int id, RoomFacility roomFacility)
        {
            await _roomFacilityService.UpdateRoomFacility(roomFacility);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomFacility(int id)
        {
            await _roomFacilityService.DeleteRoomFacility(id);
            return Ok();
        }
    }
}
