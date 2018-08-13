using Autofac;
using MVCWebProjectBLL.Services;

namespace MVCWebProject.Utilities
{
    public class AutoFacPLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(PagingList<>)).As(typeof(IPagingList<>));
            builder.RegisterType<UsersService>().As<IUsersService>();
        }
    }
}