using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public ICollection<City>? Cities { get; set; }
    }
}
