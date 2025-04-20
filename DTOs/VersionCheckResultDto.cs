namespace OcuHubBackend.DTOs
{
    public class VersionCheckResultDto
    {
        public string Platform { get; set; } = string.Empty;
        public string MinimumVersion { get; set; } = string.Empty;
        public bool ForceUpdate { get; set; }
        public bool MigrationRequired { get; set; } = false;
        public string? MigrationNotes { get; set; }
    }
}