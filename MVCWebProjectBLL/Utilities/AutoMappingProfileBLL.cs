using AutoMapper;
using MVCWebProjectBLL.DTO;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectBLL.Utilities
{

    public class AutoMappingProfileBLL : Profile
    {
        public AutoMappingProfileBLL()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}