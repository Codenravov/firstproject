namespace MVCWebProject.ViewModels
{
    public class UsersListingViewModel : UsersViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Name
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}