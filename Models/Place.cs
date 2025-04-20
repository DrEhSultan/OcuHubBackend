// File: Models/Place.cs
using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class Place
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;   // اسم المكان الأساسي
        public string Type { get; set; } = "clinic";       // Clinic / Hospital / Center

        public Guid? CityId { get; set; }
        public City? City { get; set; }

        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }

        public string? LocationOverride { get; set; }      // لو حبينا نعرض المدينة/الدولة كـ نص موحد جاهز
        public string? Notes { get; set; }                 // ملاحظات إضافية إن وجدت

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}