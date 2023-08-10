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
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicleListWithCategory()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicleListWithModel()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicleListWithSeries()
        {
            throw new NotImplementedException();
        }



    }
}
