namespace TheProject.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheProject.DB.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TheProject.DataAccess.TheProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheProject.DataAccess.TheProjectDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.Cities.Any())
            {

                context.Cities.AddOrUpdate(x => x.Id,
                    new City() { Id = 1, Name = "Велико Търново" },
                    new City() { Id = 1, Name = "София" },
                    new City() { Id = 1, Name = "Пловдив" }
                    );

                context.SaveChanges();
            }


        }
    }
}
