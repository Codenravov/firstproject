using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MVCWebProject.Constants;

namespace MVCWebProject.Infrastructure
{
    public class TitleValidationAttribute : ValidationAttribute
    {
        //private readonly List<string> titles = UsersControllerConst.Titles;
        private readonly List<string> titles = new List<string>(new string[] { "Miss", "Ms", "Mr", "Sir", "Mrs", "Dr", "Lady", "Lord" });

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (titles.Any(t => t != value.ToString()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}