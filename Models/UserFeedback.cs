// Path: Models/UserFeedback.cs

using System;
using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserFeedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = default!;

        [Required]
        public string ToolName { get; set; } = default!;

        public string FeedbackText { get; set; } = string.Empty;

        public int? Rating { get; set; } // optional

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}