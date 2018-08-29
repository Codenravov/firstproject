using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MVCWebProject.Constants;
using MVCWebProject.Infrastructure;

namespace MVCWebProject.ViewModels
{
    public class UsersCreatViewModel : UsersViewModel
    {
        private readonly SelectList titles = ViewModelsConst.GetTitles;

        [Display(Name = "Phone", ResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessageResourceName = "RegularErrPhone",
            ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        public string Phone { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceName = "RequiredErrEmail", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessageResourceName = "RegularErrEmail", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [StringLength(30, ErrorMessageResourceName = "LengthErrEmail", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        public string Email { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [Required(ErrorMessageResourceName = "RequiredErrTitle", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [TitleValidation(ErrorMessageResourceName = "ServerErrTitle", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        public string Title { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [Required(ErrorMessageResourceName = "RequiredErrCountry", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [CountryValidation(ErrorMessageResourceName = "ServerErrCountry", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        public string Country { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [Required(ErrorMessageResourceName = "RequiredErrCity", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [CityValidation(ErrorMessageResourceName = "ServerErrCity", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        public string City { get; set; }

        [Display(Name = "Comments", ResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessageResourceName = "LengthErrComments", ErrorMessageResourceType = typeof(Resources.ViewModels.UsersCreatViewModel))]
        public string Comments { get; set; }

        public SelectList Titles
        {
            get
            {
                return titles;
            }
        }

        public SelectList Countries { get; set; }

        public SelectList Cities { get; set; }
    }
}