using TheProject.DB.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TheProject.DataAccess
{
    public class TheProjectDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<CarsParts> CarsParts { get; set; }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedTime = DateTime.UtcNow;
                }

                ((BaseEntity)entry.Entity).UpdatedTime = DateTime.UtcNow;
            }
        }
     
    }
}
