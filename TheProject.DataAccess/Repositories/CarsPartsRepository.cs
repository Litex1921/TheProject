using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProject.DB.Entities;

namespace TheProject.DataAccess.Repositories
{    public class CarsPartsRepository: BaseRepository<CarsParts>
    {
        private TheProject.DataAccess.TheProjectDbContext context;

        public CarsPartsRepository(TheProject.DataAccess.TheProjectDbContext context)
        {
            this.context = context;
        }

        public void Save(CarsParts carsparts)
        {
            if (carsparts.Name == null)
            {
                Create(carsparts);
            }
            else
            {
                Update(carsparts, item => item.Name == carsparts.Name);
            }
        }
    }
    
}
