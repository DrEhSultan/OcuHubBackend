using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserProfileGenerated
    {
        [Key]
        public Guid UserId { get; set; }
        public string? InferredSubspecialties { get; set; }
        public string? InferredPlaces { get; set; }
        public DateTime GeneratedAt { get; set; }

        public User? User { get; set; }
    }
}
