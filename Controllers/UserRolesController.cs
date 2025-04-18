// File: Controllers/UserRolesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcuHubBackend.Data;
using OcuHubBackend.Models;

namespace OcuHubBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly OcuHubDbContext _context;

        public UserRolesController(OcuHubDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetUserRoles()
        {
            return await _context.UserRoles.ToListAsync();
        }
    }
}