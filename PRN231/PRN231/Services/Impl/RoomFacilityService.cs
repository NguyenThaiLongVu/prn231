using PRN231.Entities;
using PRN231.Repositories;
using PRN231.Responses;

namespace PRN231.Services.Impl
{
    public class RoomFacilityService : IRoomFacilityService
    {
        private readonly IRoomFacilityRepository _roomFacilityRepository;

        public RoomFacilityService(IRoomFacilityRepository roomFacilityRepository)
        {
            _roomFacilityRepository = roomFacilityRepository;
        }

        public async Task<bool> AddRoomFacility(RoomFacility roomFacility)
        {
            await _roomFacilityRepository.AddAsync(roomFacility);
            return true;
        }

        public async Task<bool> DeleteRoomFacility(int id)
        {
            await _roomFacilityRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<RoomFacilityReponse>> GetRoomFacilities()
        {
            return await _roomFacilityRepository.GetRoomFacilities();
        }

        public async Task<RoomFacility> GetRoomFacility(int id)
        {
            return await _roomFacilityRepository.GetRoomFacility(id);
        }

        public async Task<bool> UpdateRoomFacility(RoomFacility roomFacility)
        {
            await _roomFacilityRepository.UpdateAsync(roomFacility);
            return true;
        }
    }
}
