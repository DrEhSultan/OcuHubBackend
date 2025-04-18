using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserProfileCustom
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Subspecialties { get; set; }
        public string? Degrees { get; set; }
        public string? Places { get; set; }

        public User? User { get; set; }
    }
}
