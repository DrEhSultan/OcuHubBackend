// File: Controllers/UserProfileCustomController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileCustomController : ControllerBase
{
    private readonly OcuHubDbContext _context;

    public UserProfileCustomController(OcuHubDbContext context)
    {
        _context = context;
    }

    [HttpGet("{firebaseUid}")]
    public async Task<ActionResult<UserProfileCustom>> GetUserProfile(string firebaseUid)
    {
        var profile = await _context.UserProfileCustoms
            .FirstOrDefaultAsync(p => p.FirebaseUid == firebaseUid);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }

    [HttpPost]
    public async Task<IActionResult> SaveProfile(UserProfileCustom profile)
    {
        var existing = await _context.UserProfileCustoms
            .FirstOrDefaultAsync(p => p.FirebaseUid == profile.FirebaseUid);

        if (existing == null)
        {
            profile.CreatedAt = DateTime.UtcNow;
            profile.UpdatedAt = DateTime.UtcNow;

            _context.UserProfileCustoms.Add(profile);
        }
        else
        {
            existing.FullName = profile.FullName;
            existing.ProfessionTitle = profile.ProfessionTitle;
            existing.DegreeId = profile.DegreeId;
            existing.CountryId = profile.CountryId;
            existing.CityId = profile.CityId;
            existing.SubspecialtyId = profile.SubspecialtyId;
            existing.UpdatedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
        return Ok();
    }
}