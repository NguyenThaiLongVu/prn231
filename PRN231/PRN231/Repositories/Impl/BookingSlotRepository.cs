using Microsoft.EntityFrameworkCore;
using PRN231.Entities;

namespace PRN231.Repositories.Impl
{
    public class BookingSlotRepository : Repository<BookingSlot>, IBookingSlotRepository
    {
        public BookingSlotRepository(ApplicationDbContext context) : base(context) { }
        public async Task<IEnumerable<BookingSlot>> GetAllBookingSlot()
        {
            return await _context.BookingSlots.ToListAsync();
        }
    }
}
