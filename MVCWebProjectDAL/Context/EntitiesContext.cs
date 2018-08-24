using System.Data.Entity;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Context
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext()
        {
        }

        public EntitiesContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }
    }
}