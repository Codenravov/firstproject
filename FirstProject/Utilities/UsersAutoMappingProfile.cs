using AutoMapper;
using MVCWebProject.ViewModels;
using MVCWebProjectBLL.DTO;

namespace MVCWebProject.Utilities
{

    public class UsersAutoMappingProfile : Profile
    {
        public UsersAutoMappingProfile()
        {
            CreateMap<UsersCreatViewModel, PersonDTO>();
            CreateMap<PersonDTO, UsersListingViewModel>();
            CreateMap<UsersEditViewModel, PersonDTO>().ReverseMap();
            CreateMap<PersonDTO, UsersDeleteViewModel>();
            CreateMap<PersonDTO, UsersCommentsViewModel>();
        }
    }
}