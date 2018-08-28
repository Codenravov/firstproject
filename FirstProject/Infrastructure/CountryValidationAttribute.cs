using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MVCWebProjectBLL.Services;

namespace MVCWebProject.Infrastructure
{
    public class CountryValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IValidationService validationService = DependencyResolver.Current.GetService<IValidationService>();
            if (value != null)
            {
                if (!validationService.CheckCountry(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}