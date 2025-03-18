using Microsoft.EntityFrameworkCore;
using PRN231.Entities;

namespace PRN231.Repositories.Impl
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateOnly date, int slotId)
        {
            var bookedRoomIds = await _context.Bookings
        .Where(b => b.SlotID == slotId && b.BookingDate.Date == date.ToDateTime(new TimeOnly()).Date)
        .Select(b => b.RoomID)
        .ToListAsync();
            Console.WriteLine(string.Join(", ", bookedRoomIds));
            // Lọc danh sách phòng dựa trên danh sách đã đặt
            return await _context.Rooms
                .Include(r => r.RoomFacilities)
                .Where(r => !bookedRoomIds.Contains(r.RoomID))
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _context.Rooms
                .Include(r => r.RoomFacilities)
                .ThenInclude(rf => rf.Facility)
                .ToListAsync();
        }
    }
}
