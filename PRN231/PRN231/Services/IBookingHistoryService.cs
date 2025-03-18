using PRN231.Entities;

namespace PRN231.Services
{
    public interface IBookingHistoryService
    {
        Task<IEnumerable<BookingHistory>> GetAllBookingHistoryAsync();
        Task<IEnumerable<BookingHistory>> GetBookingHistoryByRoomAsync(int roomId);
        Task<IEnumerable<BookingHistory>> GetUserBookingHistoryAsync(int userId);
        Task<IEnumerable<BookingHistory>> SearchBookingHistoryAsync(string keyword);
        Task AddBookingHistoryAsync(BookingHistory bookingHistory);
        Task UpdateBookingHistoryAsync(BookingHistory bookingHistory);
        Task DeleteBookingHistoryAsync(int bookingHistoryId);
    }
}
