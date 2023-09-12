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
        public List<Vehicle> ListVehicleWithCategory(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model.Series.Brand.Category).Where(y=>y.Model.Series.Brand.CategoryID ==id).ToList();
            }
        }

        public List<Vehicle> ListVehicleWithCategoryUser(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model.Series.Brand.Category).Where(x=>x.UserID == id).ToList();
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
        public List<Vehicle> ListVehicleWithBrand(int id)
        {
            using (var c = new Context())
            {
                var y = c.Vehicles.Include(x => x.Model.Series.Brand).Where(y=>y.Model.Series.BrandID ==id).ToList();
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
        public List<Vehicle> ListVehicleWithSeries(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model.Series).Where(y=>y.Model.SeriesID == id).ToList();
            }
        }

        public List<Vehicle> ListVehicleWithModel()
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model).ToList();
            }
        }
        public List<Vehicle> ListVehicleWithModel(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(x => x.Model).Where(y=>y.ModelID == id).ToList();
            }
        }



        public Vehicle ByModel(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(y => y.Model).Where(x => x.VehicleID == id).FirstOrDefault();
            }
           
        }

        public Vehicle BySeries(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(y => y.Model.Series).Where(x => x.VehicleID == id).FirstOrDefault();
            }
        }

        public Vehicle ByBrand(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(y => y.Model.Series.Brand).Where(x => x.VehicleID == id).FirstOrDefault();
            }
        }
            

        public Vehicle ByCategory(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Include(y => y.Model.Series.Brand.Category).Where(x => x.VehicleID == id).FirstOrDefault();
            }
        }

        public Vehicle ByIdWithCt(int id)
        {
            using (var c = new Context())
            {
                return c.Vehicles.Where(x=>x.VehicleID==id).Include(x => x.Model.Series.Brand.Category).Include(y => y.User).FirstOrDefault();
            }
        }
    }
}
