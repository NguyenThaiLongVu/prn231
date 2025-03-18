using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231.Entities;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingApiController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingHistoryService _bookHistoryService;

        public BookingApiController(IBookingService bookingService, IBookingHistoryService bookHistoryService)
        {
            _bookingService = bookingService;
            _bookHistoryService = bookHistoryService;
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> GetBookingsByRoom(int roomId)
        {
            var result = await _bookingService.GetBookingHistoryByRoomAsync(roomId);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var result = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(result);
        }

        [HttpGet("slot-availability")]
        public async Task<IActionResult> IsSlotAvailable([FromQuery] int roomId, [FromQuery] int slotId, [FromQuery] DateOnly date)
        {
            var result = await _bookingService.IsSlotAvailable(roomId, slotId, date);
            return Ok(result);
        }
        [HttpPost("add-booking")]
        public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        {
            await _bookingService.AddBooking(booking);
            return Ok();
        }
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingBookings()
        {
            var pendingBookings = await _bookingService.GetPendingBookingsAsync();
            return Ok(pendingBookings);
        }
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveBooking(int id)
        {
            var result = await _bookingService.ApproveBookingAsync(id);
            Booking booking = await _bookingService.GetBookingByIdAsync(id);
            await AddBookingHistory(booking, "Completed");
            return result ? Ok("Booking được duyệt!") : BadRequest("Duyệt thất bại!");
        }

        [HttpPost("reject/{id}")]
        public async Task<IActionResult> RejectBooking(int id)
        {
            var result = await _bookingService.RejectBookingAsync(id);
            Booking booking = await _bookingService.GetBookingByIdAsync(id);
            await AddBookingHistory(booking, "Rejected");
            return result ? Ok("Booking bị từ chối!") : BadRequest("Từ chối thất bại!");
        }
        private async Task AddBookingHistory(Booking booking, string status)
        {
            await _bookHistoryService.AddBookingHistoryAsync(new BookingHistory()
            {
                BookingID = booking.BookingID,
                UserID = booking.UserID,
                RoomID = booking.RoomID,
                Status = status,
                SlotID = booking.SlotID,
                BookingDate = booking.BookingDate,
                ProcessedBy = 5,
                ProcessedAt = DateTime.Now,
            });
        }
    }
}
