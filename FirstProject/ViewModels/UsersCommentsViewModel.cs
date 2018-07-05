namespace MVCWebProject.ViewModels
{
    public class UsersCommentsViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Comments { get; set; }

        public string Name
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}