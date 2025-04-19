using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.DTOs
{
    public class UserDto
    {
        [Required]
        public string FirebaseUid { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        public string PhotoUrl { get; set; }

        public string AuthProvider { get; set; }

        public bool EmailVerified { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastLoginAt { get; set; }
    }
}