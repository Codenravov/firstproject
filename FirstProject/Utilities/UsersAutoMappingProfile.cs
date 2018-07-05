namespace MVCWebProject.Utilities
{
    using AutoMapper;
    using MVCWebProject.DAL;
    using MVCWebProject.ViewModels;

    public class UsersAutoMappingProfile : Profile
    {
        public UsersAutoMappingProfile()
        {
            CreateMap<UsersCreatViewModel, Person>();
            CreateMap<Person, UsersListingViewModel>();
            CreateMap<UsersEditViewModel, Person>().ReverseMap();
            CreateMap<Person, UsersDeleteViewModel>();
            CreateMap<Person, UsersCommentsViewModel>();
        }
    }
}