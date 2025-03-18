using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRN231.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        public int RoomID { get; set; }
        public Room? Room { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public int SlotID { get; set; }
        public BookingSlot? Slot { get; set; }

        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Completed
        public bool AgreementAccepted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
