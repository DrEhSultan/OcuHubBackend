// File: Models/Notification.cs
using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class Notification
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Type { get; set; } = "system";             // system | update | tip...
        public string Source { get; set; } = "auto";             // auto | admin | api

        public bool IsCritical { get; set; } = false;
        public bool IsUserConfigurable { get; set; } = true;

        public DateTime ValidFrom { get; set; } = DateTime.UtcNow;
        public DateTime? ValidTo { get; set; }

        public string? TargetQueryJson { get; set; }             // NEW

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}