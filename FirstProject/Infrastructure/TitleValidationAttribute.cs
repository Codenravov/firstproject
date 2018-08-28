using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using MVCWebProject.Constants;
using MVCWebProjectBLL.Services;

namespace MVCWebProject.Infrastructure
{
    public class TitleValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                SelectList titles = ViewModelsConst.GetTitles;
                foreach (SelectListItem item in titles.Items)
                {
                    if (item.Text == value.ToString())
                    {
                        return ValidationResult.Success;
                    }
                }

                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}