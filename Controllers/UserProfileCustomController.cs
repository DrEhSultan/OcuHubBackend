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
    public async Task<ActionResult<UserProfileCustom>> GetProfile(string firebaseUid)
    {
        var profile = await _context.UserProfileCustoms
            .FirstOrDefaultAsync(p => p.FirebaseUid == firebaseUid);

        if (profile == null)
            return NotFound();

        return Ok(profile);
    }

    [HttpPost]
    public async Task<ActionResult<UserProfileCustom>> CreateOrUpdateProfile(UserProfileCustom model)
    {
        var existing = await _context.UserProfileCustoms
            .FirstOrDefaultAsync(p => p.FirebaseUid == model.FirebaseUid);

        if (existing != null)
        {
            existing.FullName = model.FullName;
            existing.ProfessionTitle = model.ProfessionTitle;
            existing.DegreeId = model.DegreeId;
            existing.CountryId = model.CountryId;
            existing.CityId = model.CityId;
            existing.SubspecialtyId = model.SubspecialtyId;
            existing.WorkPlace = model.WorkPlace;
            existing.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            model.CreatedAt = DateTime.UtcNow;
            model.UpdatedAt = DateTime.UtcNow;
            _context.UserProfileCustoms.Add(model);
        }

        await _context.SaveChangesAsync();
        return Ok(model);
    }
}