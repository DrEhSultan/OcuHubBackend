using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class ToolFeedback
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ToolId { get; set; }
        public Tool? Tool { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public string Type { get; set; } = "feedback"; // suggestion / complaint
        public string Message { get; set; } = string.Empty;
        public int? Rating { get; set; }

        public bool IsOffline { get; set; }
        public DateTime? SyncedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
