using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRN231.Entities
{
    public class UserAgreement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgreementID { get; set; }

        public int UserID { get; set; }
        public User User { get; set; } = null!;

        public string AgreementText { get; set; } = string.Empty;
        public DateTime AcceptedAt { get; set; } = DateTime.UtcNow;
    }

}
