using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AGL.Api.ApplicationCore.Models.Validation
{
    public class EmailValidation : ValidationAttribute
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string emailString)
            {
                if (EmailRegex.IsMatch(emailString))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"{validationContext.DisplayName} must be a valid email address.");
        }
    }
}
