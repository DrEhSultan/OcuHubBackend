// File: Controllers/UserNotificationsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotificationsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserNotificationsController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserNotification>>> GetUserNotifications(string userId)
        {
            if (!Guid.TryParse(userId, out var userGuid))
                return BadRequest("Invalid userId format.");

            var notifications = await _context.UserNotifications
                .Include(x => x.Notification)
                .Where(n => n.UserId == userGuid)
                .ToListAsync();

            return Ok(notifications);
        }

        [HttpPost("mark-as-read")]
        public async Task<IActionResult> MarkAsRead(Guid userId, Guid notificationId)
        {
            var existing = await _context.UserNotifications
                .FirstOrDefaultAsync(x => x.UserId == userId && x.NotificationId == notificationId);

            if (existing != null)
            {
                if (!existing.IsSeen)
                {
                    existing.IsSeen = true;
                    existing.SeenAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }

            var log = new UserNotification
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                NotificationId = notificationId,
                IsSeen = true,
                SeenAt = DateTime.UtcNow,
                DeliveredAt = DateTime.UtcNow
            };

            _context.UserNotifications.Add(log);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}