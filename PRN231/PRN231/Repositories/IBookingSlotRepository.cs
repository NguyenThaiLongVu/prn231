using PRN231.Entities;

namespace PRN231.Repositories
{
    public interface IBookingSlotRepository: IRepository<BookingSlot>
    {
        Task<IEnumerable<BookingSlot>> GetAllBookingSlot();
    }
}
