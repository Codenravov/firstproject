using Autofac;
using MVCWebProjectDAL.Context;
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
            builder.RegisterType<CityRepository>().As<ICityRepository>().WithParameter("context", new EntitiesContext());
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().WithParameter("context", new EntitiesContext());
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().WithParameter("context", new EntitiesContext());
        }
    }
}
