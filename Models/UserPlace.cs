using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserPlace
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid PlaceId { get; set; }
        public Place? Place { get; set; }

        public string? RelationType { get; set; }
        public string? CityOverride { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
