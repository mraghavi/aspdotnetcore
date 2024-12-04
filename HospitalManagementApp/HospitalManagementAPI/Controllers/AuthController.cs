using Microsoft.AspNetCore.Mvc;
using HospitalManagementAPI.Models;
using HospitalManagementAPI.Data;
using Microsoft.AspNetCore.Identity.Data;

namespace HospitalManagementAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] User newUser)
        {
            if (MockRepository.Users.Any(u => u.Email == newUser.Email))
            {
                return BadRequest("Email already exists.");
            }

            MockRepository.Users.Add(newUser);
            return Ok(newUser);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var user = MockRepository.Users.FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(user);
        }

        [HttpGet("profile")]
        public IActionResult GetProfile([FromQuery] string email)
        {
            var user = MockRepository.Users.FirstOrDefault(u => u.Email == email && u.Role == "Doctor");
            if (user == null) return NotFound("Doctor not found");

            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            });
        }
    }
}
