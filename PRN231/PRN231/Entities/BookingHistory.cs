using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRN231.Entities
{
    public class BookingHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryID { get; set; }

        public int BookingID { get; set; }
        public Booking Booking { get; set; } = null!;

        public int UserID { get; set; }
        public User User { get; set; } = null!;

        public int RoomID { get; set; }
        public Room Room { get; set; } = null!;

        public int SlotID { get; set; }
        public BookingSlot Slot { get; set; } = null!;

        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? ProcessedBy { get; set; }
        public User? ProcessedUser { get; set; }
        public DateTime? ProcessedAt { get; set; }
    }

}
