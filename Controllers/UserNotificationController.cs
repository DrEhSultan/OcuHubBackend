using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotificationController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserNotificationController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserNotification>>> GetUserNotifications(string userId)
        {
            var notifications = await _context.UserNotifications
                .Where(n => n.UserId == userId)
                .ToListAsync();

            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult<UserNotification>> PostUserNotification(UserNotification notification)
        {
            _context.UserNotifications.Add(notification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserNotifications), new { userId = notification.UserId }, notification);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var notification = await _context.UserNotifications.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }

            _context.UserNotifications.Remove(notification);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
