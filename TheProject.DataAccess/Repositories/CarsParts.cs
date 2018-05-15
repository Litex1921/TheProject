using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProject.DB.Entities;

namespace TheProject.DataAccess.Repositories
{     class CarsPartsRepository: BaseRepository<CarsParts>
    {
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
