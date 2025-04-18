using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class SubSpecialty
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
