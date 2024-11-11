using System.ComponentModel.DataAnnotations;
using UserRegistrationAPI.Validators;

namespace UserRegistrationAPI.Models
{
    public class UserRegistration
    {
        [Required(ErrorMessage = "Username is required")]
        [Username(ErrorMessage = "Username should not contain spaces, commas, or special characters except for '_'")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Password(ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one number, and one special character")]
        public string Password { get; set; }
    }
}
