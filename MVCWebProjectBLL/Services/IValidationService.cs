using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebProjectBLL.Services
{
    public interface IValidationService
    {
        bool CheckCountry(string countryName);

        bool CheckCity(string cityName);
    }
}
