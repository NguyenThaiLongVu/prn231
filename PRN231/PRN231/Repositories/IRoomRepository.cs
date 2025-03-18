using PRN231.Entities;

namespace PRN231.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateOnly date, int slotId);
        Task<IEnumerable<Room>> GetRoomsAsync();
    }
}
