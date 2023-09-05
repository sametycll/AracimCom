using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;   
        }


        public Vehicle GetById(int id)
        {
            return _vehicleDal.GetByID(id);
        }

        public List<Vehicle> GetListAll()
        {
            return _vehicleDal.GetList();
        }

        
        public void TAdd(Vehicle t)
        {
            _vehicleDal.Insert(t);
        }

        public void TDelete(Vehicle t)
        {
            _vehicleDal.Delete(t);
        }

        public void TUpdate(Vehicle t)
        {
            _vehicleDal.Update(t);
        }


        public List<Vehicle> GetVehicleListWithBrand()
        {
            return _vehicleDal.ListVehicleWithBrand();
        }

        public List<Vehicle> GetVehicleListWithCategory()
        {
            return _vehicleDal.ListVehicleWithCategory();
        }

        public List<Vehicle> GetVehicleListWithModel()
        {
            return _vehicleDal.ListVehicleWithModel();
        }

        public List<Vehicle> GetVehicleListWithSeries()
        {
            return _vehicleDal.ListVehicleWithSeries();
        }

        public Vehicle GetByModel(int id)
        {
            return _vehicleDal.ByModel(id);
        }
        public Vehicle GetBySeries(int id)
        {
            return _vehicleDal.BySeries(id);
        }
        public Vehicle GetByBrand(int id)
        {
            return _vehicleDal.ByBrand(id);
        }
        public Vehicle GetByUser(int id)
        {
            return _vehicleDal.ByUser(id);
        }

        public Vehicle GetByCategory(int id) { 

             return _vehicleDal.ByCategory(id);
        }

    public List<Vehicle> GetListVehicleWithCategoryUser(int id)
        {
            return _vehicleDal.ListVehicleWithCategoryUser(id);
        }

      

    }
}
