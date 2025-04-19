using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolUsageLogController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public ToolUsageLogController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<ToolUsageLog>>> GetLogs(Guid userId)
        {
            var logs = await _context.ToolUsageLogs
                .Where(l => l.UserId == userId)
                .ToListAsync();

            return Ok(logs);
        }

        [HttpPost]
        public async Task<IActionResult> SaveLog(ToolUsageLog log)
        {
            log.CreatedAt = DateTime.UtcNow;
            _context.ToolUsageLogs.Add(log);
            await _context.SaveChangesAsync();
            return Ok(log);
        }
    }
}