// File: Models/UserPlace.cs
using System.ComponentModel.DataAnnotations;

namespace OcuHubBackend.Models
{
    public class UserPlace
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid? PlaceId { get; set; }                  // مرتبط بجدول موحّد (اختياري)
        public Place? Place { get; set; }

        public string? CustomPlaceName { get; set; }        // لو كتب اسم يدويًا
        public string? Location { get; set; }               // المدينة أو الدولة
        public string? Type { get; set; }                   // Clinic / Hospital / Center

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}