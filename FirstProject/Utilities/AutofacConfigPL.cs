using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVCWebProjectBLL.Services;

namespace MVCWebProject.Utilities
{

    public class AutofacConfigPL
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterModule(new AutoMapperModule());
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterGeneric(typeof(PagingList<>)).As(typeof(IPagingList<>));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}