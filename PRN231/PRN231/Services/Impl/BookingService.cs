using PRN231.Entities;
using PRN231.Repositories;

namespace PRN231.Services
{
    public class BookingService: IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            await _bookingRepository.AddAsync(booking);
            return true;
        }

        public async Task<bool> ApproveBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            booking.Status = "Completed";
            await _bookingRepository.UpdateAsync(booking);
            return true;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetBookingHistoryByRoomAsync(int roomId)
        {
            return await _bookingRepository.GetBookingHistoryByRoomAsync(roomId);
        }

        public async Task<IEnumerable<Booking>> GetPendingBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();
            bookings = bookings.Where(b => b.Status == "Pending");
            return bookings;
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _bookingRepository.GetUserBookingsAsync(userId);
        }

        public async Task<bool> IsSlotAvailable(int roomId, int slotId, DateOnly date)
        {
            return await _bookingRepository.IsSlotAvailable(roomId, slotId, date);
        }

        public async Task<bool> RejectBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            booking.Status = "Rejected";
            await _bookingRepository.UpdateAsync(booking);
            return true;
        }

        public async Task<bool> RemoveBooking(int id)
        {
            await _bookingRepository.DeleteAsync(id);
            return true;
        }
    }
}
