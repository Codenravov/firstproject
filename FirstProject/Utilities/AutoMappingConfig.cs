﻿using System.Collections.Generic;
using Autofac;
using AutoMapper;
using MVCWebProject.ViewModels;
using MVCWebProjectDAL;

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