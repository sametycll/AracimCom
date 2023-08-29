using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfVehicleRepository:GenericRepository<Vehicle>,IVehicleDal
    {
        public List<Vehicle> ListVehicleWithCategory()
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model.Series.Brand.Category).ToList();
            }
        }

        public List<Vehicle> ListVehicleWithBrand()
        {
            using (var c = new Context())
            {
                var y = c.Vehicles.Include(x => x.Model.Series.Brand).ToList();
                return y;
            }
        }

        public List<Vehicle> ListVehicleWithSeries()
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model.Series).ToList();
            }
        }

        public List<Vehicle> ListVehicleWithModel()
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model).ToList();
            }
        }
    }
}
