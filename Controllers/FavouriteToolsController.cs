using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavouriteToolsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public FavouriteToolsController(OcuHubDbContext context)
        {
            _context = context;
        }

        // GET: api/FavouriteTools/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavouritesByUser(Guid userId)
        {
            var favourites = await _context.FavouriteTools
                .Include(f => f.Tool)
                .Where(f => f.UserId == userId)
                .OrderBy(f => f.CustomOrder)
                .ToListAsync();

            return Ok(favourites);
        }

        // POST: api/FavouriteTools
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateFavourite([FromBody] FavouriteTool favourite)
        {
            var existing = await _context.FavouriteTools
                .FirstOrDefaultAsync(f => f.UserId == favourite.UserId && f.ToolId == favourite.ToolId);

            if (existing != null)
            {
                existing.CustomOrder = favourite.CustomOrder;
                existing.IsCustom = favourite.IsCustom;
                existing.UsageCount = favourite.UsageCount;
                existing.UsageScore = favourite.UsageScore;
                existing.LastUsedAt = favourite.LastUsedAt;
                _context.FavouriteTools.Update(existing);
            }
            else
            {
                favourite.Id = Guid.NewGuid();
                favourite.CreatedAt = DateTime.UtcNow;
                _context.FavouriteTools.Add(favourite);
            }

            await _context.SaveChangesAsync();
            return Ok(favourite);
        }

        // DELETE: api/FavouriteTools/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(Guid id)
        {
            var fav = await _context.FavouriteTools.FindAsync(id);
            if (fav == null) return NotFound();

            _context.FavouriteTools.Remove(fav);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
