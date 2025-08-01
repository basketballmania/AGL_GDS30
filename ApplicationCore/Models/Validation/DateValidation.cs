using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AGL.Api.ApplicationCore.Models.Validation
{
    public class DateValidation : ValidationAttribute
    {
        private readonly string _dateFormat = "yyyyMMdd";

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string dateString)
            {
                if (DateTime.TryParseExact(dateString, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"{validationContext.DisplayName} must be a valid date in yyyyMMdd format.");
        }
    }

}
