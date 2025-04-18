using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserAppSettings
    {
        [Key]
        public Guid UserId { get; set; }

        public string NotificationMode { get; set; } = "all";
        public string DefaultSortMethod { get; set; } = "usage";
        public bool ShowTips { get; set; } = true;
        public bool ShowSubspecialties { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User? User { get; set; }
    }
}
