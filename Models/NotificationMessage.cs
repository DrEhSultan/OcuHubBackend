using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class NotificationMessage
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Type { get; set; } = "general"; // general | tip | update
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public string? TargetQueryJson { get; set; } // JSON string to target users
    }
}