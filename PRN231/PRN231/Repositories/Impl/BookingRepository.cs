using Microsoft.EntityFrameworkCore;
using PRN231.Entities;

namespace PRN231.Repositories.Impl
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Booking>> GetBookingHistoryByRoomAsync(int roomId)
        {
            return await _context.Bookings
                .Where(b => b.RoomID == roomId)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserID == userId)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> IsSlotAvailable(int roomId, int slotId, DateOnly date)
        {
            return !await _context.Bookings.AnyAsync(b => b.RoomID == roomId && b.SlotID == slotId && DateOnly.FromDateTime(b.BookingDate) == date);
        }
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.Room)
                .Include(b => b.User)
                .Include(b => b.Slot)
                .ToListAsync();
        }
    }


}
