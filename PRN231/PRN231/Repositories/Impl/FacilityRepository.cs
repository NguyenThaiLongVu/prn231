using Microsoft.EntityFrameworkCore;
using PRN231.Entities;

namespace PRN231.Repositories.Impl
{
    public class FacilityRepository : Repository<Facility>, IFacilityRepository
    {
        public FacilityRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Facility>> GetFacilities()
        {
            return await _context.Facilities.ToListAsync();
        }

        public async Task<IEnumerable<Facility>> GetFacilitiesByRoomIdAsync(int roomId)
        {
            return await _context.Facilities
                .Where(f => _context.RoomFacilities.Any(rf => rf.RoomID == roomId && rf.FacilityID == f.FacilityID))
                .ToListAsync();
        }
    }
}
