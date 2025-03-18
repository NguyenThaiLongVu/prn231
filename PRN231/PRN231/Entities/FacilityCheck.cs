using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRN231.Entities
{
    public class FacilityCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckID { get; set; }

        public int BookingID { get; set; }
        public Booking Booking { get; set; } = null!;

        public int FacilityID { get; set; }
        public Facility Facility { get; set; } = null!;

        public int CheckedBy { get; set; }
        public User User { get; set; } = null!;

        public string Status { get; set; } = "OK"; // OK, Damaged
        public string? Notes { get; set; }
        public DateTime CheckedAt { get; set; } = DateTime.UtcNow;
    }

}
