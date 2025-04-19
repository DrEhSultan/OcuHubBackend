using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models;

public class UserProfileCustom
{
    [Key]
    public Guid UserId { get; set; }

    public string FirebaseUid { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string ProfessionTitle { get; set; } = null!;
    public int? DegreeId { get; set; }
    public int? CountryId { get; set; }
    public int? CityId { get; set; }
    public int? SubspecialtyId { get; set; }
    public string? WorkPlace { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}