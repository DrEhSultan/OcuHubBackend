// File: Controllers/AppVersionRequirementsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppVersionRequirementsController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public AppVersionRequirementsController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var versions = await _context.AppVersionRequirements.ToListAsync();
            return Ok(versions);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody] AppVersionRequirement version)
        {
            var existing = await _context.AppVersionRequirements
                .FirstOrDefaultAsync(v => v.Platform == version.Platform);

            if (existing != null)
            {
                existing.MinimumVersion = version.MinimumVersion;
                existing.ForceUpdate = version.ForceUpdate;
                existing.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                version.UpdatedAt = DateTime.UtcNow;
                _context.AppVersionRequirements.Add(version);
            }

            await _context.SaveChangesAsync();
            return Ok(version);
        }
    }
}
