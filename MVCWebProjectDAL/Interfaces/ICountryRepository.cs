using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetCountries(Expression<Func<Country, bool>> filter = null, Func<Country, object> orderBy = null);

        Country GetCountry(string countryName);
    }
}
