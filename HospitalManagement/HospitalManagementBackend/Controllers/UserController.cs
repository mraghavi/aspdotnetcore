using HospitalManagementBackend.Models;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementBackend.Data;

namespace HospitalManagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Register method
        [HttpPost("register")]
        public IActionResult Register([FromBody] User newUser)
        {
            if (MockDataRepository.Users.Any(u => u.Username == newUser.Username))
            {
                return BadRequest("Username already exists.");
            }

            newUser.Id = Guid.NewGuid();
            MockDataRepository.Users.Add(newUser);
            return Ok(newUser);
        }

        // Login method
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = MockDataRepository.Users
                .FirstOrDefault(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(user);
        }

        // Get all users by role (Admin functionality)
        [HttpGet("users")]
        public IActionResult GetUsersByRole(string role)
        {
            var users = MockDataRepository.Users
                .Where(u => u.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
                .Select(u => u.Username)
                .ToList();

            return Ok(users);
        }
    }
}
