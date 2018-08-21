using AutoMapper;
using MVCWebProject.ViewModels;
using MVCWebProjectBLL.DTO;

namespace MVCWebProject.Utilities
{
    public class AutoMappingPLProfile : Profile
    {
        public AutoMappingPLProfile()
        {
            CreateMap<UsersCreatViewModel, PersonDTO>();
            CreateMap<PersonDTO, UsersListingViewModel>();
            CreateMap<UsersEditViewModel, PersonDTO>().ReverseMap();
            CreateMap<PersonDTO, UsersDeleteViewModel>();
            CreateMap<PersonDTO, UsersCommentsViewModel>();
        }
    }
}