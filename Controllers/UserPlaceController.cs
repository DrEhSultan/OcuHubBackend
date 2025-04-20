// File: Controllers/UserPlaceController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPlaceController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserPlaceController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserPlaces(string userId)
        {
            if (!Guid.TryParse(userId, out var userGuid))
                return BadRequest("Invalid user ID");

            var userPlaces = await _context.UserPlaces
                .Include(p => p.Place)
                .Where(up => up.UserId == userGuid)
                .ToListAsync();

            return Ok(userPlaces);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> SaveUserPlaces(string userId, [FromBody] List<UserPlace> places)
        {
            if (!Guid.TryParse(userId, out var userGuid))
                return BadRequest("Invalid user ID");

            var oldPlaces = _context.UserPlaces.Where(up => up.UserId == userGuid);
            _context.UserPlaces.RemoveRange(oldPlaces);

            foreach (var p in places)
            {
                p.Id = Guid.NewGuid();
                p.UserId = userGuid;
                p.CreatedAt = DateTime.UtcNow;
                _context.UserPlaces.Add(p);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}