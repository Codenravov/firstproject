﻿using Autofac;
using Autofac.Integration.Mvc;
using MVCWebProject.DAL;
using MVCWebProject.DAL.Interfaces;
using MVCWebProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebProject.Utilities
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //builder.RegisterType(typeof(PersonRepository<>)).As(typeof(IRepository<>)).WithParameter("context", new PersonContext());

            builder.RegisterGeneric(typeof(PersonRepository<>)).As(typeof(IRepository<>)).WithParameter("context", new PersonContext());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}