using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MVCWebProjectBLL.DTO;
using MVCWebProjectBLL.Service;
using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;

namespace MVCWebProjectBLL.Services
{
    public class UsersServiceBLL : IUsersServiceBLL
    {
        private readonly ICityRepository cityRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public UsersServiceBLL(
            ICityRepository cityRepository,
            ICountryRepository countryRepository,
            IPersonRepository personRepository,
            IMapper mapper)
        {
            this.cityRepository = cityRepository;
            this.countryRepository = countryRepository;
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public IEnumerable<PersonDTO> GetPeople(string searchString, string sortOption)
        {
            string property = this.personRepository.GetPersonProperties().First();
            if (!string.IsNullOrEmpty(sortOption) && this.personRepository.GetPersonProperties().Any(x => x == sortOption))
            {
                property = sortOption;
            }

            var source = this.personRepository.GetPeople(
                p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString),
                orderBy: s => s.GetType().GetProperty(property).GetValue(s, null));
            var people = this.mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(source);
            return people;
        }

        public PersonDTO GetPerson(int id)
        {
            Person person = this.personRepository.GetPersonById(id);
            var model = this.mapper.Map<Person, PersonDTO>(person);
            return model;
        }

        public SelectList GetCountries()
        {
            SelectList countries = new SelectList(this.countryRepository.GetCountries(orderBy: x => x.CountryName), "CountryName", "CountryName");
            return countries;
        }

        public SelectList GetCities(string countryName)
        {
            Country country = this.countryRepository.GetCountry(countryName);
            SelectList cities = new SelectList(country.Cities, "CityName", "CityName");
            return cities;
        }

        public void AddPerson(PersonDTO model)
        {
            var person = this.mapper.Map<PersonDTO, Person>(model);
            this.personRepository.AddPerson(person);
        }

        public void UpdatePerson(PersonDTO model)
        {
            var person = this.mapper.Map<PersonDTO, Person>(model, this.personRepository.GetPersonById(model.Id));
            this.personRepository.UpdatePerson(person);
        }

        public void DeletePerson(int id)
        {
            this.personRepository.DeletePersonById(id);
        }
    }
}
