using TheProject.DB.Entities;

namespace TheProject.DataAccess.Repositories
{
    public class LocationRepository : BaseRepository<Location>
    {
        private TheProject.DataAccess.TheProjectDbContext context;

        public LocationRepository(TheProject.DataAccess.TheProjectDbContext context)
        {
            this.context = context;
        }

        public void Save(Location location)
        {
            if (location.Id == 0)
            {
                Create(location);
            }
            else
            {
                Update(location, item => item.Id == location.Id);
            }
        }
    }
}
