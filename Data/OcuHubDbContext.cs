using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Models;

namespace OcuHubBackend.Data
{
    public class OcuHubDbContext : DbContext
    {
        public OcuHubDbContext(DbContextOptions<OcuHubDbContext> options) : base(options) { }

        // === Users & Profiles ===
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; } = default!;
        public DbSet<UserProfileCustom> UserProfileCustoms { get; set; } = default!;
        public DbSet<UserProfileGenerated> UserProfileGenerateds { get; set; } = default!;
        public DbSet<UserAppSettings> UserAppSettings { get; set; } = default!;
        public DbSet<UserPlace> UserPlaces { get; set; } = default!;
        public DbSet<UserFeedback> UserFeedbacks { get; set; } = default!;

        // === Locations & Places ===
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Place> Places { get; set; } = default!;
        public DbSet<UsageLocation> UsageLocations { get; set; } = default!;

        // === Medical Tools ===
        public DbSet<Tool> Tools { get; set; } = default!;
        public DbSet<ToolCategory> ToolCategories { get; set; } = default!;
        public DbSet<FavouriteTool> FavouriteTools { get; set; } = default!;
        public DbSet<ToolUsageLog> ToolUsageLogs { get; set; } = default!;
        public DbSet<ToolFeedback> ToolFeedbacks { get; set; } = default!;

        // === Education & Subspecialties ===
        public DbSet<Degree> Degrees { get; set; } = default!;
        public DbSet<SubSpecialty> SubSpecialties { get; set; } = default!;

        // === Notifications ===
        public DbSet<Notification> Notifications { get; set; } = default!;
        public DbSet<NotificationRole> NotificationRoles { get; set; } = default!;
        public DbSet<NotificationMessage> NotificationMessages { get; set; } = default!;
        public DbSet<UserNotification> UserNotifications { get; set; } = default!;
        public DbSet<UserNotificationStatus> UserNotificationStatuses { get; set; } = default!;

        // === Version Control ===
        public DbSet<AppVersionRequirement> AppVersionRequirements { get; set; } = default!;
    }
}