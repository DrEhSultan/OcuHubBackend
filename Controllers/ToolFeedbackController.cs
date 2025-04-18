using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToolFeedbackController : ControllerBase
{
    private readonly OcuHubDbContext _context;

    public ToolFeedbackController(OcuHubDbContext context)
    {
        _context = context;
    }

    [HttpGet("tool/{toolId}")]
    public async Task<IActionResult> GetFeedbacksForTool(Guid toolId)
    {
        var feedbacks = await _context.ToolFeedbacks
            .Where(f => f.ToolId == toolId)
            .OrderByDescending(f => f.CreatedAt)
            .ToListAsync();

        return Ok(feedbacks);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitFeedback([FromBody] ToolFeedback feedback)
    {
        feedback.CreatedAt = DateTime.UtcNow;

        _context.ToolFeedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return Ok(feedback);
    }
}