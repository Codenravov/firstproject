using AutoMapper;
using MVCWebProjectBLL.DTO;
using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCWebProjectBLL.Services
{
    public interface IUsersService
    {
        IEnumerable<PersonDTO> GetPeople(string searchString, string sortOption);

        PersonDTO GetPerson(int id);

        SelectList GetCountries();

        SelectList GetCities(string country);

        void SavePerson(PersonDTO model);

        void UpdatePerson(PersonDTO model);

        void DeletePerson(int id);

    }

    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork dataBase;
        private readonly IMapper mapper;

        public UsersService(
            IUnitOfWork dataBase,
            IMapper mapper)
        {
            this.dataBase = dataBase;
            this.mapper = mapper;
        }

        public IEnumerable<PersonDTO> GetPeople(string searchString, string sortOption)
        {
            string property = this.dataBase.People.GetPersonProperties().First();
            if (!string.IsNullOrEmpty(sortOption) && this.dataBase.People.GetPersonProperties().Any(x => x == sortOption))
            {
                property = sortOption;
            }

            var source = this.dataBase.People.GetPeople(
                p => (p.FirstName.ToLower() + p.LastName.ToLower()).Contains(searchString),
                orderBy: s => s.GetType().GetProperty(property).GetValue(s, null));
            var people = this.mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(source);
            return people;
        }

        public PersonDTO GetPerson(int id)
        {
            Person person = this.dataBase.People.GetPersonById(id);
            var model = this.mapper.Map<Person, PersonDTO>(person);
            return model;
        }


        public SelectList GetCountries()
        {
            SelectList countries = new SelectList(this.dataBase.Countries.GetCountries(orderBy: x => x.CountryName), "CountryName", "CountryName");
            return countries;
        }

        public SelectList GetCities(string country)
        {
            SelectList cities = new SelectList(this.dataBase.Cities.GetCities(x => x.CountryName.Contains(country), orderBy: x => x.CityName), "CityName", "CityName");
            return cities;
        }

        public void SavePerson(PersonDTO model)
        {
            var person = this.mapper.Map<PersonDTO, Person>(model);
            this.dataBase.People.AddOrUpdatePerson(person);
        }

        public void UpdatePerson(PersonDTO model)
        {
            var person = this.mapper.Map<PersonDTO, Person>(model, this.dataBase.People.GetPersonById(model.Id));
            this.dataBase.People.AddOrUpdatePerson(person);
        }

        public void DeletePerson(int id)
        {
            this.dataBase.People.DeletePersonById(id);
        }
    }
}
