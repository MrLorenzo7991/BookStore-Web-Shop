using System.ComponentModel.DataAnnotations;

namespace BookStore_Web_Shop.Validation
{
    public class MoreThan0Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double number = (double)value;
            if (number <= 0)
            {
                return new ValidationResult("Il numero deve essere maggiore di 0");
            }
            return ValidationResult.Success;
        }
    }
}
