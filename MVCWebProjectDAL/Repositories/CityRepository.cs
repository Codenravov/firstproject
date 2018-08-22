using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Entities;
using MVCWebProjectDAL.Interfaces;

namespace MVCWebProjectDAL.Repositories
{
    public class CityRepository : EntityRepository<City>, ICityRepository
    {
        public CityRepository(EntitiesContext context) : base(context)
        {
        }

        public List<City> GetCities(Expression<Func<City, bool>> filter = null, Func<City, object> orderBy = null)
        {
            return Get(filter, orderBy);
        }
    }
}
