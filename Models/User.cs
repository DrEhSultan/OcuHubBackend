using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcuHubBackend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirebaseUid { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Guid RoleId { get; set; }
        public UserRole? Role { get; set; }

        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }

        public int? GraduationYear { get; set; }
        public DateTime? ProfessionStart { get; set; }

        public bool IsTester { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
