using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserRegistrationAPI.Validators
{
    public class UsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is string username))
            {
                return new ValidationResult("Invalid username format.");
            }

            var regex = new Regex("^[a-zA-Z0-9_]+$");
            if (!regex.IsMatch(username))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
