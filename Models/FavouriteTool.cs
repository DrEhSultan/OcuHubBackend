using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class FavouriteTool
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid ToolId { get; set; }
        public Tool? Tool { get; set; }

        public int CustomOrder { get; set; }
        public bool IsCustom { get; set; }

        public int UsageCount { get; set; }
        public double UsageScore { get; set; }

        public DateTime? LastUsedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
