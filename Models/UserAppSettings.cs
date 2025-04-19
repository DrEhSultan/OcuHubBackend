namespace OcuHubBackend.Models
{
    public class UserAppSettings
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public string NotificationMode { get; set; } = "All"; // Default value
        public string DefaultSortMethod { get; set; } = "ByCategory"; // Default value
        public bool ShowTips { get; set; } = true;
        public bool ShowSubspecialties { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}