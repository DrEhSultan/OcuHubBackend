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
            {
                return BadRequest("Invalid userId format.");
            }

            var notifications = await _context.UserNotifications
                .Where(n => n.UserId == userGuid)
                .ToListAsync();

            return Ok(notifications);
        }
    }
}