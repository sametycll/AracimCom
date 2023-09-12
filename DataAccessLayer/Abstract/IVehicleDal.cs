using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IVehicleDal : IGenericDal<Vehicle>
    {
        public List<Vehicle> ListVehicleWithCategory(int id);
        public List<Vehicle> ListVehicleWithCategory();
        public List<Vehicle> ListVehicleWithBrand();
        public List<Vehicle> ListVehicleWithBrand(int id);
        public List<Vehicle> ListVehicleWithSeries();
        public List<Vehicle> ListVehicleWithSeries(int id);
        public List<Vehicle> ListVehicleWithModel();
        public List<Vehicle> ListVehicleWithModel(int id);
        public Vehicle ByModel(int id);
        public Vehicle BySeries(int id);
        public Vehicle ByBrand(int id);
        public Vehicle ByCategory(int id);
        public List<Vehicle> ListVehicleWithCategoryUser(int id);

        public Vehicle ByIdWithCt(int id);

    }
}
