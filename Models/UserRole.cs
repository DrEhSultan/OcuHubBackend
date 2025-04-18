using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserRole
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<User>? Users { get; set; }
    }
}
