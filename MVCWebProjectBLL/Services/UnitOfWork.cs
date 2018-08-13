using MVCWebProjectDAL.Interfaces;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectBLL.Services
{
    public interface IUnitOfWork
    {
        IRepository<Person> Peoples { get; }

        IRepository<Country> Countries { get; }

        IRepository<City> Cities { get; }
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Person> peoples;
        private readonly IRepository<Country> countries;
        private readonly IRepository<City> cities;

        public UnitOfWork(
            IRepository<Person> peoples,
            IRepository<Country> countries,
            IRepository<City> cities)
        {
            this.peoples = peoples;
            this.countries = countries;
            this.cities = cities;
        }

        public IRepository<Person> Peoples
        {
            get
            {
                return peoples;
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return countries;
            }
        }

        public IRepository<City> Cities
        {
            get
            {
                return cities;
            }
        }
    }
}
