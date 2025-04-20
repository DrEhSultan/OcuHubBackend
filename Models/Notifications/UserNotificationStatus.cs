using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models.Notifications
{
    public class UserNotificationStatus
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid NotificationMessageId { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
    }
}