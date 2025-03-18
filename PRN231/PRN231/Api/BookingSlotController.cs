using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/booking-slot")]
    [ApiController]
    public class BookingSlotController : ControllerBase
    {
        private readonly IBookingSlotService bookingSlotService;

        public BookingSlotController(IBookingSlotService bookingSlotService)
        {
            this.bookingSlotService = bookingSlotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookingSlot()
        {
            var res = await bookingSlotService.GetBookingSlots();
            return Ok(res);
        }
    }
}
