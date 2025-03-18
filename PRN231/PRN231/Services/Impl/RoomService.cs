using PRN231.Entities;
using PRN231.Repositories;

namespace PRN231.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<bool> AddRoom(Room room)
        {
            await _roomRepository.AddAsync(room);
            return true;
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _roomRepository.GetRoomsAsync();
        }

        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateOnly date, int slotId)
        {
            return await _roomRepository.GetAvailableRoomsAsync(date, slotId);
        }

        public async Task<bool> RemoveRoom(int id)
        {
            await _roomRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> UpdateRoom(Room room)
        {
            await _roomRepository.UpdateAsync(room);
            return true;
        }
    }
}
