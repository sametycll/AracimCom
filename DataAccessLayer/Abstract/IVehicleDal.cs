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
        public List<Vehicle> ListVehicleWithCategory();
        public List<Vehicle> ListVehicleWithBrand();
        public List<Vehicle> ListVehicleWithSeries();
        public List<Vehicle> ListVehicleWithModel();
        public Vehicle ByModel(int id);
        public Vehicle BySeries(int id);
        public Vehicle ByBrand(int id);
        public Vehicle ByCategory(int id);
        public List<Vehicle> ListVehicleWithCategoryUser(int id);

        public Vehicle ByIdWithCt(int id);

    }
}
