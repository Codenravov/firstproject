using Autofac;
using MVCWebProjectDAL.Interfaces;
using MVCWebProjectDAL.Repositories;
using MVCWebProjectDAL.Utilities;

namespace MVCWebProjectBLL.Utilities
{
    public class AutoFacBLLModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AutoFacDALModule>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
