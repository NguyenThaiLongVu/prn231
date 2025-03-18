using PRN231.Entities;

namespace PRN231.Repositories
{
    public interface IFacilityRepository : IRepository<Facility>
    {
        Task<IEnumerable<Facility>> GetFacilitiesByRoomIdAsync(int roomId);
        Task<IEnumerable<Facility>> GetFacilities();
    }

}
