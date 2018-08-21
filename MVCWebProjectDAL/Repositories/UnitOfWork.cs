using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;

namespace MVCWebProjectDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICityRepository cities;
        private readonly ICountryRepository countries;
        private readonly IPersonRepository people;

        public UnitOfWork(
            ICityRepository cities,
            ICountryRepository countries,
            IPersonRepository people)
        {
            this.cities = cities;
            this.countries = countries;
            this.people = people;
        }

        public IPersonRepository People
        {
            get
            {
                return people;
            }
        }

        public ICountryRepository Countries
        {
            get
            {
                return countries;
            }
        }

        public ICityRepository Cities
        {
            get
            {
                return cities;
            }
        }
    }
}
