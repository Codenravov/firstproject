using Autofac;
using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Interfaces;
using MVCWebProjectDAL.Repositories;

namespace MVCWebProjectDAL.Utilities
{
    public class AutoFacDALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EntitiesRepository<>)).As(typeof(IRepository<>)).WithParameter("context", new EntitiesContext());
        }
    }
}
