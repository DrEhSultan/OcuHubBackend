// File: Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Country)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("firebase/{firebaseUid}")]
        public async Task<ActionResult<User>> GetUserByFirebaseUid(string firebaseUid)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Country)
                .FirstOrDefaultAsync(u => u.FirebaseUid == firebaseUid);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User updatedUser)
        {
            if (id != updatedUser.Id) return BadRequest();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;
            user.RoleId = updatedUser.RoleId;
            user.CountryId = updatedUser.CountryId;
            user.GraduationYear = updatedUser.GraduationYear;
            user.ProfessionStart = updatedUser.ProfessionStart;
            user.IsTester = updatedUser.IsTester;

            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}