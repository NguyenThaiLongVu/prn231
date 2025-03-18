using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRN231.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string? Description { get; set; }

        public ICollection<RoomFacility> RoomFacilities { get; set; } = new List<RoomFacility>();
    }

}
