namespace MVCWebProject.Utilities
{
    using AutoMapper;
    using MVCWebProject.ViewModels;
    using MVCWebProjectDAL.Entities;

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