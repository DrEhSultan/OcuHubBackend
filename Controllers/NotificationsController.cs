// File: Controllers/NotificationsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public NotificationsController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserNotifications(Guid userId)
        {
            var notifications = await _context.UserNotifications
                .Include(n => n.Notification)
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.DeliveredAt)
                .ToListAsync();

            return Ok(notifications);
        }

        [HttpPost("mark-seen/{id}")]
        public async Task<IActionResult> MarkAsSeen(Guid id)
        {
            var noti = await _context.UserNotifications.FindAsync(id);
            if (noti == null) return NotFound();

            noti.IsSeen = true;
            noti.SeenAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok(noti);
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification(Notification notification)
        {
            notification.Id = Guid.NewGuid();
            notification.CreatedAt = DateTime.UtcNow;

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return Ok(notification);
        }
    }
}