using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstProject.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}   public class PersonDbInitializer : DropCreateDatabaseAlways<PersonContext>
    {
    protected override void Seed(PersonContext db)
    {
        db.People.Add(new Person
        {
            FirstName = "Igor",
            LastName = "Dobronravov",
            Phone = "(800) 555-1212",
            Email = "dobronravov@gmail.com",
            Title = Title.Mr,
            Country = Countries.USA,
            City = Cities.NewYork,
            Comments = "Just for fun"
        });
        db.People.Add(new Person
        {
            FirstName = "Dima",
            LastName = "Blagonravov",
            Phone = "(800) 555-1212",
            Email = "Blgnrvv@gmail.com",
            Title = Title.Ms,
            Country = Countries.UK,
            City = Cities.Birmingham,
            Comments = "I'm here"
        });
        db.People.Add(new Person
        {
            FirstName = "Lena",
            LastName = "Nravovna",
            Phone = "(800) 555-1212",
            Email = "NravovnaLn@gmail.com",
            Title = Title.Lord,
            Country = Countries.China,
            City = Cities.Shanghai,
            Comments = "Russian world"
        });
        db.People.Add(new Person
        {
            FirstName = "Neves",
            LastName = "Emos",
            Phone = "(800) 555-1212",
            Email = "EmosNeves@gmail.com",
            Title = Title.Lady,
            Country = Countries.Canada,
            City = Cities.Ottawa,
            Comments = "Tagi-i-i-i-i-l!!!"
        });
        db.People.Add(new Person
        {
            FirstName = "Mikola",
            LastName = "Hryharuk",
            Phone = "(800) 555-1212",
            Email = "mikolahr@gmail.com",
            Title = Title.Sir,
            Country = Countries.Germany,
            City = Cities.Munich,
            Comments = "Hello world"
        });

        base.Seed(db);
    }
}