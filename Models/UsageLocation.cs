using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UsageLocation
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Guid? CityId { get; set; }
        public City? City { get; set; }

        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }

        public double? Accuracy { get; set; }
        public string Source { get; set; } = "gps";
        public string Purpose { get; set; } = "tool_use";

        public bool IsOffline { get; set; }
        public DateTime? SyncedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
