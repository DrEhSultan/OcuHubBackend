// File: Controllers/ToolUsageLogsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolUsageLogsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public ToolUsageLogsController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<ToolUsageLog>>> GetToolUsageLogsByUser(Guid userId)
        {
            return await _context.ToolUsageLogs
                .Where(log => log.UserId == userId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ToolUsageLog>> LogToolUsage(ToolUsageLog log)
        {
            log.Id = Guid.NewGuid();
            log.CreatedAt = DateTime.UtcNow;
            _context.ToolUsageLogs.Add(log);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetToolUsageLogsByUser), new { userId = log.UserId }, log);
        }
    }
}