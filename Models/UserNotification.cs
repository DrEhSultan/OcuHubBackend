using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserNotification
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid NotificationId { get; set; }
        public Notification? Notification { get; set; }

        public bool IsSeen { get; set; }
        public DateTime? SeenAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
