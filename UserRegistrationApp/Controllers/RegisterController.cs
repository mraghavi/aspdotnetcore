using Microsoft.AspNetCore.Mvc;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] UserRegistration user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(new { Message = "Registration successful" });
        }
    }
}
