using Microsoft.EntityFrameworkCore;
using PRN231.Entities;

namespace PRN231.Repositories.Impl
{
    public class BookingHistoryRepository : Repository<BookingHistory>, IBookingHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingHistoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Lấy toàn bộ lịch sử mượn phòng
        public async Task<IEnumerable<BookingHistory>> GetAllBookingHistoryAsync()
        {
            return await _context.BookingHistories
                .Include(bh => bh.User)
                .Include(bh => bh.Room)
                .Include(bh => bh.Slot)
                .OrderByDescending(bh => bh.BookingDate)
                .ToListAsync();
        }

        // Lấy lịch sử mượn theo RoomID
        public async Task<IEnumerable<BookingHistory>> GetBookingHistoryByRoomAsync(int roomId)
        {
            return await _context.BookingHistories
                .Where(bh => bh.RoomID == roomId)
                .Include(bh => bh.User)
                .Include(bh => bh.Room)
                .Include(bh => bh.Slot)
                .OrderByDescending(bh => bh.BookingDate)
                .ToListAsync();
        }

        // Lấy lịch sử mượn theo UserID
        public async Task<IEnumerable<BookingHistory>> GetUserBookingHistoryAsync(int userId)
        {
            return await _context.BookingHistories
                .Where(bh => bh.UserID == userId)
                .Include(bh => bh.User)
                .Include(bh => bh.Room)
                .Include(bh => bh.Slot)
                .Include(bh => bh.ProcessedUser)
                .OrderByDescending(bh => bh.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingHistory>> SearchBookingHistoryAsync(string keyword)
        {
            return await _context.BookingHistories
                .Where(bh => bh.Room.RoomName.Contains(keyword) || bh.User.FullName.Contains(keyword))
                .Include(bh => bh.User)
                .Include(bh => bh.Room)
                .OrderByDescending(bh => bh.BookingDate)
                .ToListAsync();
        }

        public async Task AddBookingHistoryAsync(BookingHistory bookingHistory)
        {
            await _context.BookingHistories.AddAsync(bookingHistory);
            await _context.SaveChangesAsync();
        }

        // Cập nhật lịch sử mượn phòng
        public async Task UpdateBookingHistoryAsync(BookingHistory bookingHistory)
        {
            _context.BookingHistories.Update(bookingHistory);
            await _context.SaveChangesAsync();
        }

        // Xóa lịch sử mượn phòng
        public async Task DeleteBookingHistoryAsync(int bookingHistoryId)
        {
            var history = await _context.BookingHistories.FindAsync(bookingHistoryId);
            if (history != null)
            {
                _context.BookingHistories.Remove(history);
                await _context.SaveChangesAsync();
            }
        }
    }

}
