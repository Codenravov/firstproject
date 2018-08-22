namespace MVCWebProject.ViewModels
{
    public class UsersDeleteViewModel : UsersViewModel
    {
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}