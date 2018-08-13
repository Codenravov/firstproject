using Autofac;
using MVCWebProjectBLL.Services;
using MVCWebProjectBLL.Utilities;

namespace MVCWebProject.Utilities
{
    public class AutoFacPLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoFacBLLModule>();
            builder.RegisterGeneric(typeof(PagingList<>)).As(typeof(IPagingList<>));
            builder.RegisterType<UsersService>().As<IUsersService>();
        }
    }
}