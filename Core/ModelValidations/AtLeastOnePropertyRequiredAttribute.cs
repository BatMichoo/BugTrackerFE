using System.ComponentModel.DataAnnotations;

namespace Presentation.ModelValidations
{
    public class AtLeastOnePropertyRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("The object cannot be null.");

            var properties = value.GetType().GetProperties();
            var hasValue = properties.Any(p => p.GetValue(value) != null);

            if (hasValue)
            {
                return ValidationResult.Success!;
            }

            return new ValidationResult("At least one property must have a value.");
        }
    }
}
