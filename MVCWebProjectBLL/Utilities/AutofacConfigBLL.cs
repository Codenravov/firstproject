using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVCWebProjectBLL.Services;
using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Interfaces;
using MVCWebProjectDAL.Repositories;

namespace MVCWebProjectBLL.Utilities
{
    public class AutofacConfigBLL
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterGeneric(typeof(EntitiesRepository<>)).As(typeof(IRepository<>)).WithParameter("context", new EntitiesContext());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
