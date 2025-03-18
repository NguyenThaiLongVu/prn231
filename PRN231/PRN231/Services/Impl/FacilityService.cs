using PRN231.Entities;
using PRN231.Repositories;

namespace PRN231.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _facilityRepository;

        public FacilityService(IFacilityRepository facilityRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public Task<IEnumerable<Facility>> GetFacilities()
        {
            return _facilityRepository.GetFacilities();
        }

        public async Task<IEnumerable<Facility>> GetFacilitiesByRoomIdAsync(int roomId)
        {
            return await _facilityRepository.GetFacilitiesByRoomIdAsync(roomId);
        }
    }
}
