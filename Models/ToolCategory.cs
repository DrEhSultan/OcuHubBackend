using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class ToolCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
