using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class Degree
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
