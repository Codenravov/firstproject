using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;

namespace MVCWebProjectBLL.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ICityRepository cityRepository;
        private readonly ICountryRepository countryRepository;

        public ValidationService(
            ICityRepository cityRepository,
            ICountryRepository countryRepository)
        {
            this.cityRepository = cityRepository;
            this.countryRepository = countryRepository;
        }

        public bool CheckCountry(string countryName)
        {
            List<Country> list = countryRepository.GetCountries(c => c.CountryName == countryName, c => c.Id);
            if (list.Count != 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckCity(string cityName)
        {
            List<City> list = cityRepository.GetCities(c => c.CityName == cityName, c => c.Id);
            if (list.Count != 0)
            {
                return true;
            }

            return false;
        }
    }
}
