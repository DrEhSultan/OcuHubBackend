using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFeedbackController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserFeedbackController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserFeedback>>> GetFeedback(string userId)
        {
            var feedbacks = await _context.UserFeedbacks
                .Where(f => f.UserId.ToString() == userId)
                .ToListAsync();

            return Ok(feedbacks);
        }

        [HttpPost]
        public async Task<ActionResult<UserFeedback>> PostFeedback(UserFeedback feedback)
        {
            _context.UserFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeedback), new { userId = feedback.UserId }, feedback);
        }
    }
}