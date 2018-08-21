using MVCWebProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebProjectDAL.Interfaces
{
    public interface ICityRepository
    {
        List<City> GetCities(Expression<Func<City, bool>> filter = null, Func<City, object> orderBy = null);
    }
}
