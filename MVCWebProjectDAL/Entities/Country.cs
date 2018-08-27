using System.Collections.Generic;

namespace MVCWebProjectDAL.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}