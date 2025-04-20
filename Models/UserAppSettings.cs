using System.ComponentModel.DataAnnotations.Schema;

namespace OcuHubBackend.Models
{
    public class UserAppSettings
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; } // ✅ النوع بقى مطابق لـ User.Id
        public User User { get; set; } = null!;

        public string NotificationMode { get; set; } = "All";
        public string DefaultSortMethod { get; set; } = "ByCategory";
        public bool ShowTips { get; set; } = true;
        public bool ShowSubspecialties { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}