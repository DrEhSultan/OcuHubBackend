using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class NotificationRole
    {
        [Key]
        public Guid Id { get; set; }

        public Guid NotificationId { get; set; }
        public Notification? Notification { get; set; }

        public Guid RoleId { get; set; }
        public UserRole? Role { get; set; }
    }
}
