using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcuHubBackend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirebaseUid { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? PhotoUrl { get; set; }

        public string? AuthProvider { get; set; }

        public bool EmailVerified { get; set; } = false;

        public DateTime? LastLoginAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Guid RoleId { get; set; }

        public UserRole? Role { get; set; }

        public Guid? CountryId { get; set; }

        public Country? Country { get; set; }

        public int? GraduationYear { get; set; }

        public DateTime? ProfessionStart { get; set; }

        public bool IsTester { get; set; }
    }
}