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
            builder.RegisterType<CityRepository>().As<ICityRepository>().WithParameter("context", new EntitiesContext());
            builder.RegisterType<CountryRepository>().As<ICountryRepository>().WithParameter("context", new EntitiesContext());
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().WithParameter("context", new EntitiesContext());
        }
    }
}
