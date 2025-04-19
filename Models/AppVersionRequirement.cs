using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models;

public class AppVersionRequirement
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Platform { get; set; } = null!;  // "ios" أو "android"

    [Required]
    public string MinimumVersion { get; set; } = null!;

    public bool ForceUpdate { get; set; } = false;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}