using Autofac;
using AutoMapper;
using MVCWebProject.DAL;
using MVCWebProject.ViewModels;
using System.Collections.Generic;

public class AutoMapperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(AutoMapperModule).Assembly).As<Profile>();

        builder.Register(context => new MapperConfiguration(cfg =>
        {
            foreach (var profile in context.Resolve<IEnumerable<Profile>>())
            {
                cfg.AddProfile(profile);
            }
        })).AsSelf().SingleInstance();

        builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
            .As<IMapper>()
            .InstancePerLifetimeScope();
    }
}
public class CreatUserProfile : Profile
{
    public CreatUserProfile() => CreateMap<UsersCreatViewModel, Person>();
}
public class ListingUsersProfile : Profile
{
    public ListingUsersProfile() => CreateMap<Person, UsersListingViewModel>().ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName));
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