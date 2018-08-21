using System.Collections.Generic;
using System.Data.Entity;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Context
{
    public class EntityDbInitializer : DropCreateDatabaseAlways<EntitiesContext>
    {
        protected override void Seed(EntitiesContext db)
        {
            var people = new List<Person>
            {
                new Person
                {
                    FirstName = "Igor",
                    LastName = "Dobronravov",
                    Phone = "(800) 555-1212",
                    Email = "dobronrav@gmail.com",
                    Title = "Mr",
                    Country = "United States",
                    City = "Palo Alto",
                    Comments = "Comment Text1"
                },
                new Person
                {
                    FirstName = "Dima",
                    LastName = "Blagonravov",
                    Phone = "(800) 555-1212",
                    Email = "Blgnrvv@gmail.com",
                    Title = "Ms",
                    Country = "United Kingdom",
                    City = "Oxford",
                    Comments = "Comment Text2"
                },
                new Person
                {
                    FirstName = "Lena",
                    LastName = "Nravovna",
                    Phone = "(800) 555-1212",
                    Email = "NravovnaLn@gmail.com",
                    Title = "Lord",
                    Country = "Canada",
                    City = "Montreal",
                    Comments = "Comment Text3"
                },
                new Person
                {
                    FirstName = "Neves",
                    LastName = "Emos",
                    Phone = "(800) 555-1212",
                    Email = "EmosNeves@gmail.com",
                    Title = "Lady",
                    Country = "United States",
                    City = "Atlanta",
                    Comments = "Comment Text4"
                },
                new Person
                {
                    FirstName = "Mikola",
                    LastName = "Hryharuk",
                    Phone = "(800) 555-1212",
                    Email = "mikolahr@gmail.com",
                    Title = "Sir",
                    Country = "United Kingdom",
                    City = "Cambridge",
                    Comments = "Comment Text5"
                }
            };
            var countries = new List<Country>
            {
                new Country { CountryName = "United States" },
                new Country { CountryName = "United Kingdom" },
                new Country { CountryName = "Canada" }
            };
            var cities = new List<City>
            {
                new City
                {
                    CountryName = "United States",
                    CityName = "Palo Alto"
                },
                new City
                {
                    CountryName = "United States",
                    CityName = "Atlanta"
                },
                new City
                {
                    CountryName = "United States",
                    CityName = "Houston"
                },
                new City
                {
                    CountryName = "United Kingdom",
                    CityName = "Oxford"
                },
                new City
                {
                    CountryName = "United Kingdom",
                    CityName = "Cambridge"
                },
                new City
                {
                    CountryName = "United Kingdom",
                    CityName = "Edinburgh"
                },
                new City
                {
                    CountryName = "Canada",
                    CityName = "Montreal"
                },
                new City
                {
                    CountryName = "Canada",
                    CityName = "Vancouver"
                },
                new City
                {
                    CountryName = "Canada",
                    CityName = "Ottawa"
                }
            };
            people.ForEach(p => db.People.Add(p));
            countries.ForEach(c => db.Countries.Add(c));
            cities.ForEach(c => db.Cities.Add(c));
            db.SaveChanges();
        }
    }
}