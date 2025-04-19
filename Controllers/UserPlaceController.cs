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
            var userPlaces = await _context.UserPlaces
                .Where(up => up.UserId == userId)
                .ToListAsync();

            return Ok(userPlaces);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> SaveUserPlaces(string userId, [FromBody] List<UserPlace> places)
        {
            var oldPlaces = _context.UserPlaces.Where(up => up.UserId == userId);
            _context.UserPlaces.RemoveRange(oldPlaces);

            foreach (var place in places)
            {
                place.UserId = userId;
            }

            await _context.UserPlaces.AddRangeAsync(places);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
