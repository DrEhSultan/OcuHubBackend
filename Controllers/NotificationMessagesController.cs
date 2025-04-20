using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationMessagesController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public NotificationMessagesController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationMessage message)
        {
            message.SentAt = DateTime.UtcNow;
            _context.NotificationMessages.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationMessage>>> GetAll()
        {
            return await _context.NotificationMessages
                .OrderByDescending(n => n.SentAt)
                .ToListAsync();
        }
    }
}