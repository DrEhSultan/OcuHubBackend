// 📄 File: Controllers/ToolsController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public ToolsController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tool>>> GetAllTools()
        {
            var tools = await _context.Tools
                .Include(t => t.Category)
                .OrderBy(t => t.Name)
                .ToListAsync();

            return Ok(tools);
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Tool>>> GetToolsByCategory(Guid categoryId)
        {
            var tools = await _context.Tools
                .Where(t => t.CategoryId == categoryId)
                .Include(t => t.Category)
                .OrderBy(t => t.Name)
                .ToListAsync();

            return Ok(tools);
        }
    }
}
