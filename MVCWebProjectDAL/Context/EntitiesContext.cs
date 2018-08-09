﻿using System.Data.Entity;
using MVCWebProjectDAL.Context;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Context
{

    public class EntitiesContext : DbContext
    {
        public EntitiesContext()
        {
            Database.SetInitializer(new EntityDbInitializer());
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