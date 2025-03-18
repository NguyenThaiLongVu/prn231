using PRN231.Entities;

namespace PRN231.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAll();
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateOnly date, int slotId);
        Task<bool> AddRoom(Room room);
        Task<bool> RemoveRoom(int id);
        Task<bool> UpdateRoom(Room room);

    }
}
