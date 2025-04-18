// 📄 File: Controllers/ToolCategoriesController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolCategoriesController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public ToolCategoriesController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolCategory>>> GetToolCategories()
        {
            var categories = await _context.ToolCategories
                .OrderBy(c => c.Name)
                .ToListAsync();

            return Ok(categories);
        }
    }
}
