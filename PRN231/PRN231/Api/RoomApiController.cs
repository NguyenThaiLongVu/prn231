using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231.Entities;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomApiController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomApiController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var result = await _roomService.GetAll();
            return Ok(result);
        }
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms([FromQuery] DateOnly date, [FromQuery] int slotId)
        {
            var result = await _roomService.GetAvailableRoomsAsync(date, slotId);
            return Ok(result);
        }
        [HttpPost("add-room")]
        public async Task<bool> AddRoom(Room room)
        {
            await _roomService.AddRoom(room);
            return true;
        }
        [HttpDelete("{id}")]
        public async Task<bool> RemoveRoom(int id)
        {
            await _roomService.RemoveRoom(id);
            return true;
        }
        [HttpPost("update-room")]
        public async Task<bool> UpdateRoom(Room room)
        {
            await _roomService.UpdateRoom(room);
            return true;
        }
    }
}
