using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace MVCWebProjectDAL.Repositories
{
    public class CountryRepository : EntityRepository<Country>, ICountryRepository
    {
        public CountryRepository(EntitiesContext context) : base(context)
        {

        }

        public List<Country> GetCountries(Expression<Func<Country, bool>> filter = null, Func<Country, object> orderBy = null)
        {
            return Get(filter, orderBy);
        }
    }
}
