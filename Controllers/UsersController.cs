using Microsoft.AspNetCore.Mvc;
using OcuHubBackend.DTOs;
using OcuHubBackend.Models;
using OcuHubBackend.Data;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UsersController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> SyncUser([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _context.Users.FirstOrDefault(u => u.FirebaseUid == dto.FirebaseUid);

            if (existingUser != null)
            {
                // Update user
                existingUser.Email = dto.Email;
                existingUser.Name = dto.Name;
                existingUser.PhotoUrl = dto.PhotoUrl;
                existingUser.AuthProvider = dto.AuthProvider;
                existingUser.EmailVerified = dto.EmailVerified;
                existingUser.LastLoginAt = dto.LastLoginAt;
                existingUser.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                // Create new user
                var newUser = new User
                {
                    FirebaseUid = dto.FirebaseUid,
                    Email = dto.Email,
                    Name = dto.Name,
                    PhotoUrl = dto.PhotoUrl,
                    AuthProvider = dto.AuthProvider,
                    EmailVerified = dto.EmailVerified,
                    CreatedAt = dto.CreatedAt,
                    LastLoginAt = dto.LastLoginAt,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Users.Add(newUser);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "User synced successfully" });
        }
    }
}