using PRN231.Entities;
using PRN231.Responses;

namespace PRN231.Repositories
{
    public interface IRoomFacilityRepository: IRepository<RoomFacility>
    {
        Task<IEnumerable<RoomFacilityReponse>> GetRoomFacilities();
        Task<RoomFacility> GetRoomFacility(int id);
    }
}
