using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileCustomController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserProfileCustomController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncUserProfileCustom([FromBody] UserProfileCustom customProfile)
        {
            if (customProfile == null || string.IsNullOrWhiteSpace(customProfile.UserId))
            {
                return BadRequest("Invalid profile data.");
            }

            var existing = await _context.UserProfileCustoms
                .FirstOrDefaultAsync(x => x.UserId == customProfile.UserId);

            if (existing == null)
            {
                customProfile.CreatedAt = DateTime.UtcNow;
                customProfile.UpdatedAt = DateTime.UtcNow;
                _context.UserProfileCustoms.Add(customProfile);
            }
            else
            {
                existing.Workplace = customProfile.Workplace;
                existing.PhoneNumber = customProfile.PhoneNumber;
                existing.Notes = customProfile.Notes;
                existing.Country = customProfile.Country;
                existing.City = customProfile.City;
                existing.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return Ok("UserProfileCustom synced successfully.");
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserProfileCustom>> GetProfile(string userId)
        {
            var profile = await _context.UserProfileCustoms.FirstOrDefaultAsync(p => p.UserId == userId);
            if (profile == null) return NotFound();
            return profile;
        }
    }
}
