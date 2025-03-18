using PRN231.Entities;

namespace PRN231.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingHistoryByRoomAsync(int roomId);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<bool> IsSlotAvailable(int roomId, int slotId, DateOnly date);
    }

}
