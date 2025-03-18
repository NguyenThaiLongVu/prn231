using PRN231.Entities;
using PRN231.Responses;

namespace PRN231.Services
{
    public interface IRoomFacilityService
    {
        Task<IEnumerable<RoomFacilityReponse>> GetRoomFacilities();
        Task<RoomFacility> GetRoomFacility(int id);
        Task<bool> AddRoomFacility(RoomFacility roomFacility); 
        Task<bool> UpdateRoomFacility(RoomFacility roomFacility); 
        Task<bool> DeleteRoomFacility(int id);
    }
}
