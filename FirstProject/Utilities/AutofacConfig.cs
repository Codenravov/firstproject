using Autofac;
using Autofac.Integration.Mvc;
using MVCWebProject.DAL;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.DAL.Repositories;
using MVCWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebProject.Utilities
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutoMapperModule());
            builder.RegisterGeneric(typeof(EntitiesRepository<>)).As(typeof(IRepository<>)).WithParameter("context", new EntitiesContext());
            builder.RegisterGeneric(typeof(PagedList<>)).As(typeof(IPagingList<>));
            builder.RegisterType<UsersService>().As<IUsersService>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}