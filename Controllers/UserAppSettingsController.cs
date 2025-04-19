// File: Controllers/UserAppSettingsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAppSettingsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserAppSettingsController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserAppSettings>> GetSettings(Guid userId)
        {
            var settings = await _context.UserAppSettings.FindAsync(userId);
            if (settings == null) return NotFound();
            return Ok(settings);
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncSettings([FromBody] UserAppSettings settings)
        {
            var existing = await _context.UserAppSettings.FindAsync(settings.UserId);

            if (existing != null)
            {
                existing.NotificationMode = settings.NotificationMode;
                existing.DefaultSortMethod = settings.DefaultSortMethod;
                existing.ShowTips = settings.ShowTips;
                existing.ShowSubspecialties = settings.ShowSubspecialties;
                existing.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                settings.CreatedAt = DateTime.UtcNow;
                settings.UpdatedAt = DateTime.UtcNow;
                _context.UserAppSettings.Add(settings);
            }

            await _context.SaveChangesAsync();
            return Ok(settings);
        }
    }
}