namespace MVCWebProject.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class UsersEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name*")]
        [Required(ErrorMessage = "You must provide a First name")]
        [RegularExpression(@"[A-Za-z]{1,30}([ .,'-][ ']{0,1}[A-Za-z]{2,30})*", ErrorMessage = "Not a valid First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name*")]
        [Required(ErrorMessage = "You must provide a Last name")]
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
        [EnumDataType(typeof(Title), ErrorMessage = "You must provide a Title")]
        public Title Title { get; set; }

        [Display(Name = "Country*")]
        [Required(ErrorMessage = "You must select a Country")]
        public string Country { get; set; }

        [Display(Name = "City*")]
        [Required(ErrorMessage = "You must select a City")]
        public string City { get; set; }

        [Display(Name = "Comments")]
        [DataType(DataType.MultilineText)]
        [StringLength(256, ErrorMessage = "Comments length longer than maximum allow (255)")]
        public string Comments { get; set; }

        public SelectList Countries { get; set; }

        public SelectList Cities { get; set; }
    }
}