using System.Collections.Generic;
using System.Web.Mvc;
using MVCWebProjectBLL.DTO;

namespace MVCWebProjectBLL.Service
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
}
