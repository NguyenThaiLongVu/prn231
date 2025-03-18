using PRN231.Entities;

namespace PRN231.Services
{
    public interface IFacilityService
    {
        Task<IEnumerable<Facility>> GetFacilitiesByRoomIdAsync(int roomId);
        Task<IEnumerable<Facility>> GetFacilities();
    }

}
