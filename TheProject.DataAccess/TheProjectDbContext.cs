using System;
using System.Collections.Generic;
using TheProject.DB.Entities;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace TheProject.DataAccess
{
    class TheProjectDbContext : DbContext
    {
       public DbSet<City> Cities { get; set; }

       public DbSet<Location> Locations { get; set; }

       public DbSet<CarsParts> Restaurants { get; set; }
    }
}
