using AutoMapper;
using MVCWebProjectBLL.DTO;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectBLL.Utilities
{
    public class AutoMappingBLLProfile : Profile
    {
        public AutoMappingBLLProfile()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}