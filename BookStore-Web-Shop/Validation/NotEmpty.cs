using System.ComponentModel.DataAnnotations;
namespace BookStore_Web_Shop.Validation
{
    public class NotEmpty: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string element= (string)value;
            if (element == "")
            {
                return new ValidationResult("Questo campo non può essere vuoto");
            }
            return ValidationResult.Success;
        }
    }
}



