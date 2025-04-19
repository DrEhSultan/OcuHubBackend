using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppVersionRequirementsController : ControllerBase
{
    private readonly OcuHubDbContext _context;

    public AppVersionRequirementsController(OcuHubDbContext context)
    {
        _context = context;
    }

    [HttpGet("{platform}")]
    public async Task<IActionResult> GetRequirement(string platform)
    {
        var version = await _context.AppVersionRequirements
            .FirstOrDefaultAsync(v => v.Platform.ToLower() == platform.ToLower());

        return version == null ? NotFound() : Ok(version);
    }

    [HttpPost]
    public async Task<IActionResult> SetRequirement([FromBody] AppVersionRequirement requirement)
    {
        var existing = await _context.AppVersionRequirements
            .FirstOrDefaultAsync(v => v.Platform.ToLower() == requirement.Platform.ToLower());

        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(requirement);
        }
        else
        {
            _context.AppVersionRequirements.Add(requirement);
        }

        await _context.SaveChangesAsync();
        return Ok(requirement);
    }
}