using Microsoft.EntityFrameworkCore;
using PRN231.Entities;
using PRN231.Responses;

namespace PRN231.Repositories.Impl
{
    public class RoomFacilityRepository: Repository<RoomFacility>, IRoomFacilityRepository
    {
        public RoomFacilityRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<RoomFacilityReponse>> GetRoomFacilities()
        {
            var rfResponse = new List<RoomFacilityReponse>();
            var roomFacilities = await _context.RoomFacilities
            .Include(rf => rf.Facility)
            .ToListAsync();
            foreach (var rf in roomFacilities)
            {
                rfResponse.Add(new RoomFacilityReponse()
                {
                    RoomFacilityID = rf.RoomFacilityID,
                    RoomID = rf.RoomID,
                    Room = await GetRoomByIdAsync(rf.RoomID),
                    FacilityID = rf.FacilityID,
                    Facility = rf.Facility,
                    Quantity = rf.Quantity,
                    Status = rf.Status,
                });
            }
            return rfResponse;
        }

        public async Task<RoomFacility> GetRoomFacility(int id)
        {
            return await _context.RoomFacilities
            .Include(rf => rf.Room)
            .Include(rf => rf.Facility)
            .FirstOrDefaultAsync(rf => rf.RoomFacilityID == id);
        }
        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.RoomID == id);
        }
    }
}
