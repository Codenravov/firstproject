using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;


namespace MVCWebProject.Utilities
{

    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterModule<AutoFacPLModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}