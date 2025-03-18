using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PRN231.Entities
{
    public class RoomFacility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomFacilityID { get; set; }

        public int RoomID { get; set; }
        [JsonIgnore]
        public Room? Room { get; set; }

        public int FacilityID { get; set; }
        public Facility? Facility { get; set; }

        public int Quantity { get; set; }
        public string Status { get; set; } = "OK"; // OK, Damaged
    }

}
