using MVCWebProject.DAL;
using MVCWebProject.ViewModels;
using AutoMapper;

namespace MVCWebProject.Utilities
{
    public static class AutoMappingConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new ListingUsersProfile());
                cfg.AddProfile(new CreatUserProfile());
                cfg.AddProfile(new EditUserProfile());
                cfg.AddProfile(new DeleteUserProfile());
                cfg.AddProfile(new CommentsUserProfile());
            });
        }
    }

    public class ListingUsersProfile : Profile
    {
        public ListingUsersProfile() => CreateMap<Person, UsersListingViewModel>().ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName));
    }
    public class CreatUserProfile : Profile
    {
        public CreatUserProfile() => CreateMap<UsersCreatViewModel, Person>();
    }
    public class EditUserProfile : Profile
    {
        public EditUserProfile() => CreateMap<UsersEditViewModel, Person>().ReverseMap();
    }
    public class DeleteUserProfile : Profile
    {
        public DeleteUserProfile() => CreateMap<Person, UsersDeleteViewModel>().ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName));
    }
    public class CommentsUserProfile : Profile
    {
        public CommentsUserProfile() => CreateMap<Person, UsersCommentsViewModel>().ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName));
    }
}