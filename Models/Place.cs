using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class Place
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "clinic";

        public Guid? CityId { get; set; }
        public City? City { get; set; }

        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }

        public string? Notes { get; set; }
    }
}
