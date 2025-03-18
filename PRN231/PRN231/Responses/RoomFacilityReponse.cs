using PRN231.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PRN231.Responses
{
    public class RoomFacilityReponse
    {
        public int RoomFacilityID { get; set; }

        public int RoomID { get; set; }
        public Room? Room { get; set; }

        public int FacilityID { get; set; }
        public Facility? Facility { get; set; }

        public int Quantity { get; set; }
        public string Status { get; set; } = "OK";
    }
}
