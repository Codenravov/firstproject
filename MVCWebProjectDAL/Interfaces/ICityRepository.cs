using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Interfaces
{
    public interface ICityRepository
    {
        List<City> GetCities(Expression<Func<City, bool>> filter = null, Func<City, object> orderBy = null);
    }
}
