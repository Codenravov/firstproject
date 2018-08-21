using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Interfaces
{
    public interface IPersonRepository
    {
        List<string> GetPersonProperties();

        List<Person> GetPeople(Expression<Func<Person, bool>> filter = null, Func<Person, object> orderBy = null);

        Person GetPersonById(int id);

        void AddOrUpdatePerson(Person person);

        void DeletePersonById(int id);
    }
}
