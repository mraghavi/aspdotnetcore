
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Validators
{
    public class CustomOrderDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Check if the value is a valid DateTime
            if (value is DateTime date)
            {
                // Ensure the date is on or after January 1, 2000
                if (date >= new DateTime(2000, 1, 1))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("OrderDate must be on or after 2000-01-01");
                }
            }

            // If value is not a DateTime, return an error
            return new ValidationResult("Invalid OrderDate");
        }
    }
}
