using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProject.DataAccess.Repositories;
using TheProject.DB.Entities;

namespace TheProject.DataAccess
{
    public class UnitOfWork
    {
        private  TheProjectDbContext context;

        private LocationRepository locationRepository;
        private CarsPartsRepository carspartsRepository;
        private CityRepository cityRepository;
        


        public UnitOfWork(TheProjectDbContext connection)
        {
            context = connection;
        }

        public CityRepository CityRepository
        {
            get
            {
                if (CityRepository == null)
                {
                    cityRepository = new CityRepository(context);
                }

                return CityRepository;
            }
        }

        public CarsPartsRepository CarsPartsRepository
        {
            get
            {
                if (CarsPartsRepository == null)
                {
                    carspartsRepository = new CarsPartsRepository(context);
                }

                return CarsPartsRepository;
            }
        }

        public LocationRepository LocationRepository
        {
            get
            {
                if(locationRepository == null)
                {
                    locationRepository = new LocationRepository(context);
                }

                return locationRepository;
            }
        }
    }
}
