using MVCWebProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCWebProjectDAL.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetCountries(Expression<Func<Country, bool>> filter = null, Func<Country, object> orderBy = null);
    }
}
