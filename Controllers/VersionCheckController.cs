using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.DTOs;
using OcuHubBackend.Models;
using OcuHubBackend.Data;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionCheckController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public VersionCheckController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet("{platform}")]
        public async Task<ActionResult<VersionCheckResultDto>> GetVersionRequirement(string platform)
        {
            var requirement = await _context.AppVersionRequirements
                .FirstOrDefaultAsync(r => r.Platform.ToLower() == platform.ToLower());

            if (requirement == null)
            {
                return NotFound();
            }

            var result = new VersionCheckResultDto
            {
                Platform = requirement.Platform,
                MinimumVersion = requirement.MinimumVersion,
                ForceUpdate = requirement.ForceUpdate,
                MigrationRequired = requirement.MigrationRequired,
                MigrationNotes = requirement.MigrationNotes
            };

            return Ok(result);
        }
    }
}