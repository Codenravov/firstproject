using System.ComponentModel.DataAnnotations;

namespace MVCWebProject.ViewModels
{

    public abstract class UsersViewModel
    {
        [Display(Name = "FirstName",
            ResourceType = typeof(Resources.ViewModels.UsersViewModel))]
        [Required(ErrorMessageResourceName = "RequiredErrFirstName",
            ErrorMessageResourceType = typeof(Resources.ViewModels.UsersViewModel))]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*",
            ErrorMessageResourceName = "RegularErrFirstName",
            ErrorMessageResourceType = typeof(Resources.ViewModels.UsersViewModel))]
        public string FirstName { get; set; }

        [Display(Name = "LastName",
            ResourceType = typeof(Resources.ViewModels.UsersViewModel))]
        [Required(ErrorMessageResourceName = "RequiredErrLastName",
            ErrorMessageResourceType = typeof(Resources.ViewModels.UsersViewModel))]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*$",
            ErrorMessageResourceName = "RegularErrLastName",
            ErrorMessageResourceType = typeof(Resources.ViewModels.UsersViewModel))]
        public string LastName { get; set; }
    }
}