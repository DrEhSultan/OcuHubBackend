using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class Tool
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public ToolCategory? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
