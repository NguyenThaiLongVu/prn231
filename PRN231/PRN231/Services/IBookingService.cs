using PRN231.Entities;

namespace PRN231.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingHistoryByRoomAsync(int roomId);
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<Booking> GetBookingByIdAsync(int id);
        Task<bool> IsSlotAvailable(int roomId, int slotId, DateOnly date);
        Task<bool> AddBooking(Booking booking);
        Task<bool> RemoveBooking(int id);
        Task<IEnumerable<Booking>> GetPendingBookingsAsync();
        Task<bool> ApproveBookingAsync(int id);
        Task<bool> RejectBookingAsync(int id);
    }
}
