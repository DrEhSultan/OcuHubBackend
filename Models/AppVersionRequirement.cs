using System;

namespace OcuHubBackend.Models
{
    public class AppVersionRequirement
    {
        public int Id { get; set; }
        public string Platform { get; set; } = string.Empty; // "android" or "ios"
        public string MinimumVersion { get; set; } = string.Empty;
        public bool ForceUpdate { get; set; }

        // ✅ الخصائص الجديدة:
        public bool MigrationRequired { get; set; } = false;
        public string? MigrationNotes { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}