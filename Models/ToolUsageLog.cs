using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class ToolUsageLog
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ToolId { get; set; }
        public Tool? Tool { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public int? Duration { get; set; }

        public string UsageType { get; set; } = "open";
        public string? DeviceInfo { get; set; }

        public Guid? LocationId { get; set; }
        public UsageLocation? Location { get; set; }

        public bool IsOffline { get; set; }
        public DateTime? SyncedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
