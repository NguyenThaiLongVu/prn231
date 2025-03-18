using PRN231.Entities;

namespace PRN231.Services
{
    public interface IBookingSlotService
    {
        Task<IEnumerable<BookingSlot>> GetBookingSlots();
    }
}
