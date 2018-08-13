using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVCWebProjectBLL.Utilities;


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
            builder.RegisterModule<AutoFacBLLModule>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}