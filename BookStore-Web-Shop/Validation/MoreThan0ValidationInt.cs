using System.ComponentModel.DataAnnotations;

namespace BookStore_Web_Shop.Validation
{
    public class MoreThan0ValidationInt : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int number = (int)value;
            if (number <= 0)
            {
                return new ValidationResult("Il numero deve essere maggiore di 0");
            }
            return ValidationResult.Success;
        }
    }
}
