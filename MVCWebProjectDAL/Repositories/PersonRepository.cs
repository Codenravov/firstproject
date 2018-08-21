﻿using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;


namespace MVCWebProjectDAL.Repositories
{
    public class PersonRepository : EntityRepository<Person>, IPersonRepository
    {
        public PersonRepository(EntitiesContext context) : base(context)
        {

        }

        public List<string> GetPersonProperties()
        {
            List<string> propertiesList = new List<string>();
            PropertyInfo[] properties = typeof(Person).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                propertiesList.Add(property.Name);
            }

            return propertiesList;
        }

        public List<Person> GetPeople(Expression<Func<Person, bool>> filter = null, Func<Person, object> orderBy =null)
        {
            return Get(filter, orderBy);
        }
        public Person GetPersonById(int id)
        {
            return Get(where: P => P.Id == id);
        }

        public void AddOrUpdatePerson(Person person)
        {
            if (IsExist(where: P => P.Id == person.Id))
            {
                Update(person);
            }

            else
            {
                Add(person);
            }
            Save();
        }

        public void DeletePersonById(int id)
        {
            Delete(where: P => P.Id == id);
            Save();
        }
    }
}
