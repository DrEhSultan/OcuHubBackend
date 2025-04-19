using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers;

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
    public async Task<IActionResult> GetVersionRequirements(string platform)
    {
        var requirement = await _context.AppVersionRequirements
            .Where(v => v.Platform.ToLower() == platform.ToLower())
            .FirstOrDefaultAsync();

        if (requirement == null) return NotFound();

        return Ok(requirement);
    }
}