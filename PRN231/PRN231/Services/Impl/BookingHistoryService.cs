using PRN231.Entities;
using PRN231.Repositories;

namespace PRN231.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IBookingHistoryRepository _bookingHistoryRepository;

        public BookingHistoryService(IBookingHistoryRepository bookingHistoryRepository)
        {
            _bookingHistoryRepository = bookingHistoryRepository;
        }

        public async Task<IEnumerable<BookingHistory>> GetAllBookingHistoryAsync()
        {
            return await _bookingHistoryRepository.GetAllBookingHistoryAsync();
        }

        public async Task<IEnumerable<BookingHistory>> GetBookingHistoryByRoomAsync(int roomId)
        {
            return await _bookingHistoryRepository.GetBookingHistoryByRoomAsync(roomId);
        }

        public async Task<IEnumerable<BookingHistory>> GetUserBookingHistoryAsync(int userId)
        {
            return await _bookingHistoryRepository.GetUserBookingHistoryAsync(userId);
        }

        public async Task<IEnumerable<BookingHistory>> SearchBookingHistoryAsync(string keyword)
        {
            return await _bookingHistoryRepository.SearchBookingHistoryAsync(keyword);
        }

        public async Task AddBookingHistoryAsync(BookingHistory bookingHistory)
        {
            await _bookingHistoryRepository.AddBookingHistoryAsync(bookingHistory);
        }

        public async Task UpdateBookingHistoryAsync(BookingHistory bookingHistory)
        {
            await _bookingHistoryRepository.UpdateBookingHistoryAsync(bookingHistory);
        }

        public async Task DeleteBookingHistoryAsync(int bookingHistoryId)
        {
            await _bookingHistoryRepository.DeleteBookingHistoryAsync(bookingHistoryId);
        }
    }
}
