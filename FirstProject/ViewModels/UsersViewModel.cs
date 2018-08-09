using System.ComponentModel.DataAnnotations;

namespace MVCWebProject.ViewModels
{

    public abstract class UsersViewModel
    {
        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "You must provide a First name")]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*", ErrorMessage = "Not a valid First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "You must provide a Last name")]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*$", ErrorMessage = "Not a valid Last name")]
        public string LastName { get; set; }
    }
}