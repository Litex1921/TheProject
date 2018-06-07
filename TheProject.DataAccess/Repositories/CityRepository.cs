using TheProject.DB.Entities;

namespace TheProject.DataAccess.Repositories
{

    public class CityRepository : BaseRepository<City>
    {
        private TheProject.DataAccess.TheProjectDbContext context;

        public CityRepository(TheProject.DataAccess.TheProjectDbContext context)
        {
            this.context = context;
        }

    }
}
