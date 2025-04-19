// Path: Models/ToolFeedback.cs

using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class ToolFeedback
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid ToolId { get; set; }
        public Tool? Tool { get; set; }

        public string FeedbackText { get; set; } = "";
        public int? Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}