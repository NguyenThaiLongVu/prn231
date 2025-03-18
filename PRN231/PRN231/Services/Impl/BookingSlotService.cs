using PRN231.Entities;
using PRN231.Repositories;

namespace PRN231.Services.Impl
{
    public class BookingSlotService : IBookingSlotService
    {
        private readonly IBookingSlotRepository bookingSlotRepository;

        public BookingSlotService(IBookingSlotRepository bookingSlotRepository)
        {
            this.bookingSlotRepository = bookingSlotRepository;
        }

        public Task<IEnumerable<BookingSlot>> GetBookingSlots()
        {
            return bookingSlotRepository.GetAllBookingSlot();
        }
    }
}
