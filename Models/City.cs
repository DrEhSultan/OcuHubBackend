using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
