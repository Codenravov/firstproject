using System.ComponentModel.DataAnnotations;

namespace MVCWebProject.ViewModels
{
    public class UsersCreatViewModel
    {
        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "You must provide a First name")]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*", ErrorMessage = "Not a valid First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "You must provide a Last name")]
        //[StringLength(255, ErrorMessage = "Last name length longer than maximum allow (255)")]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*$", ErrorMessage = "Not a valid Last name")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone { get; set; }

        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must provide a Email")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Display(Name = "Title*")]
        [Required(ErrorMessage = "You must provide a Title")]
        public Title Title { get; set; }

        [Display(Name = "Country*")]
        [Required(ErrorMessage = "You must provide a Country")]
        public Countries Country { get; set; }

        [Display(Name = "City*")]
        [Required(ErrorMessage = "You must provide a City")]
        public Cities City { get; set; }

        [Display(Name = "Comments")]
        [DataType(DataType.MultilineText)]
        [StringLength(256, ErrorMessage = "Comments length longer than maximum allow (255)")]
        public string Comments { get; set; }

    }

    public enum Title
    {
        Miss,
        Ms,
        Mr,
        Sir,
        Mrs,
        Dr,
        Lady,
        Lord
    }

    public enum Countries
    {
        USA,
        Canada,
        UK,
        Germany,
        China
    }

    public enum Cities
    {
        Washington,
        NewYork,
        Toronto,
        Ottawa,
        London,
        Birmingham,
        Berlin,
        Munich,
        Beijing,
        Shanghai
    }
}