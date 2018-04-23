using MVCWebProject.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebProject.DAL
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PersonContext()
        {
            Database.SetInitializer<PersonContext>(new PersonDbInitializer());
        }
        public PersonContext(string connectionString)
            : base(connectionString)
        {

        }

    }

    public class PersonDbInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext db)
        {
            db.People.Add(new Person
            {
                FirstName = "Igor",
                LastName = "Dobronravov",
                Phone = "(800) 555-1212",
                Email = "dobronrav@gmail.com",
                Title = "Mr",
                Country = "USA",
                City = "NewYork",
                Comments = "Comment Text1"
            });
            db.People.Add(new Person
            {
                FirstName = "Dima",
                LastName = "Blagonravov",
                Phone = "(800) 555-1212",
                Email = "Blgnrvv@gmail.com",
                Title = "Ms",
                Country = "UK",
                City = "Birmingham",
                Comments = "Comment Text2"
            });
            db.People.Add(new Person
            {
                FirstName = "Lena",
                LastName = "Nravovna",
                Phone = "(800) 555-1212",
                Email = "NravovnaLn@gmail.com",
                Title = "Lord",
                Country = "China",
                City = "Shanghai",
                Comments = "Comment Text3"
            });
            db.People.Add(new Person
            {
                FirstName = "Neves",
                LastName = "Emos",
                Phone = "(800) 555-1212",
                Email = "EmosNeves@gmail.com",
                Title = "Lady",
                Country = "Canada",
                City = "Ottawa",
                Comments = "Comment Text4"
            });
            db.People.Add(new Person
            {
                FirstName = "Mikola",
                LastName = "Hryharuk",
                Phone = "(800) 555-1212",
                Email = "mikolahr@gmail.com",
                Title = "Sir",
                Country = "Germany",
                City = "Munich",
                Comments = "Comment Text5"
            });

            base.Seed(db);
        }
    }
}