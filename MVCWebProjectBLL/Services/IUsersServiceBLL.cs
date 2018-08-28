using System.Collections.Generic;
using System.Web.Mvc;
using MVCWebProjectBLL.DTO;

namespace MVCWebProjectBLL.Service
{
    public interface IUsersServiceBLL
    {
        IEnumerable<PersonDTO> GetPeople(string searchString, string sortOption, bool descending);

        PersonDTO GetPerson(int id);

        SelectList GetCountries();

        SelectList GetCities(string countryName);

        void AddPerson(PersonDTO model);

        void UpdatePerson(PersonDTO model);

        void DeletePerson(int id);
    }
}
