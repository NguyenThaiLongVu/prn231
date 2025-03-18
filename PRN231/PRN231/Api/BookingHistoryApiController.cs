using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231.Entities;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/bookings-history")]
    [ApiController]
    public class BookingHistoryApiController : ControllerBase
    {
        private readonly IBookingHistoryService _bookingHistoryService;

        public BookingHistoryApiController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookingHistory()
        {
            var result = await _bookingHistoryService.GetAllBookingHistoryAsync();
            return Ok(result);
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetBookingHistoryByRoom(int roomId)
        {
            var result = await _bookingHistoryService.GetBookingHistoryByRoomAsync(roomId);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookingHistory(int userId)
        {
            var result = await _bookingHistoryService.GetUserBookingHistoryAsync(userId);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBookingHistory([FromQuery] string keyword = "")
        {
            var result = await _bookingHistoryService.SearchBookingHistoryAsync(keyword);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookingHistory([FromBody] BookingHistory bookingHistory)
        {
            await _bookingHistoryService.AddBookingHistoryAsync(bookingHistory);
            return CreatedAtAction(nameof(GetUserBookingHistory), new { userId = bookingHistory.UserID}, bookingHistory);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookingHistory([FromBody] BookingHistory bookingHistory)
        {
            await _bookingHistoryService.UpdateBookingHistoryAsync(bookingHistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingHistory(int id)
        {
            await _bookingHistoryService.DeleteBookingHistoryAsync(id);
            return NoContent();
        }
    }
}
