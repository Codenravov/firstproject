namespace MVCWebProject.ViewModels
{
    public class UsersListingViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name
        {
            get { return FirstName + " " + LastName; }
        }

    }
}