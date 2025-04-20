using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsageLocationController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UsageLocationController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UsageLocation>>> GetLocations(Guid userId)
        {
            var locations = await _context.UsageLocations
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return Ok(locations);
        }

        [HttpPost]
        public async Task<IActionResult> SaveLocation(UsageLocation location)
        {
            location.CreatedAt = DateTime.UtcNow;
            _context.UsageLocations.Add(location);
            await _context.SaveChangesAsync();

            return Ok(location);
        }
    }
}