namespace MVCWebProject.ViewModels
{
    public class UsersCommentsViewModel : UsersViewModel
    {
        public string Comments { get; set; }

        public string Name
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}