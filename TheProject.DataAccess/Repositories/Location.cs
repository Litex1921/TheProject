using TheProject.DB.Entities;

namespace TheProject.DataAccess.Repositories
{
    class LocationRepository : BaseRepository<Location>
    {
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
