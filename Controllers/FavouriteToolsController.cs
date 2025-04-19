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

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<FavouriteTool>>> GetFavourites(Guid userId)
        {
            var favs = await _context.FavouriteTools
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return Ok(favs);
        }

        [HttpPost]
        public async Task<IActionResult> SaveFavourite(FavouriteTool fav)
        {
            var existing = await _context.FavouriteTools
                .FirstOrDefaultAsync(f => f.UserId == fav.UserId && f.ToolId == fav.ToolId);

            if (existing != null)
            {
                existing.IsCustom = fav.IsCustom;
                existing.CustomOrder = fav.CustomOrder;
                existing.LastUsedAt = DateTime.UtcNow;
            }
            else
            {
                fav.CreatedAt = DateTime.UtcNow;
                _context.FavouriteTools.Add(fav);
            }

            await _context.SaveChangesAsync();
            return Ok(fav);
        }

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