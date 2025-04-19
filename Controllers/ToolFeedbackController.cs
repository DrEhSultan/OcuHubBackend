using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolFeedbackController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public ToolFeedbackController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<ToolFeedback>>> GetFeedback(Guid userId)
        {
            var feedbacks = await _context.ToolFeedbacks
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return Ok(feedbacks);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(ToolFeedback feedback)
        {
            feedback.CreatedAt = DateTime.UtcNow;
            _context.ToolFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok(feedback);
        }
    }
}