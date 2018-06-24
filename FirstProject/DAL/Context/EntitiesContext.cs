using MVCWebProject.DAL;
using MVCWebProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebProject.DAL
{
    public class EntitiesContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public EntitiesContext()
        {
            Database.SetInitializer(new EntityDbInitializer());
        }
        public EntitiesContext(string connectionString)
            : base(connectionString)
        {

        }

    }

    public class EntityDbInitializer : DropCreateDatabaseAlways<EntitiesContext>
    {
        protected override void Seed(EntitiesContext db)
        {
            db.People.Add(new Person
            {
                FirstName = "Igor",
                LastName = "Dobronravov",
                Phone = "(800) 555-1212",
                Email = "dobronrav@gmail.com",
                Title = "Mr",
                Country = "United States",
                City = "Palo Alto",
                Comments = "Comment Text1"
            });
            db.People.Add(new Person
            {
                FirstName = "Dima",
                LastName = "Blagonravov",
                Phone = "(800) 555-1212",
                Email = "Blgnrvv@gmail.com",
                Title = "Ms",
                Country = "United Kingdom",
                City = "Oxford",
                Comments = "Comment Text2"
            });
            db.People.Add(new Person
            {
                FirstName = "Lena",
                LastName = "Nravovna",
                Phone = "(800) 555-1212",
                Email = "NravovnaLn@gmail.com",
                Title = "Lord",
                Country = "Canada",
                City = "Montreal",
                Comments = "Comment Text3"
            });
            db.People.Add(new Person
            {
                FirstName = "Neves",
                LastName = "Emos",
                Phone = "(800) 555-1212",
                Email = "EmosNeves@gmail.com",
                Title = "Lady",
                Country = "United States",
                City = "Atlanta",
                Comments = "Comment Text4"
            });
            db.People.Add(new Person
            {
                FirstName = "Mikola",
                LastName = "Hryharuk",
                Phone = "(800) 555-1212",
                Email = "mikolahr@gmail.com",
                Title = "Sir",
                Country = "United Kingdom",
                City = "Cambridge",
                Comments = "Comment Text5"
            });
            db.Countries.Add(new Country { CountryName = "United States" });
            db.Countries.Add(new Country { CountryName = "United Kingdom" });
            db.Countries.Add(new Country { CountryName = "Canada" });
            db.Cities.Add(new City { CountryName = "United States", CityName = "Palo Alto" });
            db.Cities.Add(new City { CountryName = "United States", CityName = "Atlanta" });
            db.Cities.Add(new City { CountryName = "United States", CityName = "Houston" });
            db.Cities.Add(new City { CountryName = "United Kingdom", CityName = "Oxford" });
            db.Cities.Add(new City { CountryName = "United Kingdom", CityName = "Cambridge" });
            db.Cities.Add(new City { CountryName = "United Kingdom", CityName = "Edinburgh" });
            db.Cities.Add(new City { CountryName = "Canada", CityName = "Montreal" });
            db.Cities.Add(new City { CountryName = "Canada", CityName = "Vancouver" });
            db.Cities.Add(new City { CountryName = "Canada", CityName = "Ottawa" });

            base.Seed(db);
        }
    }
}