using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface IVehicleService : IGenericService<Vehicle>
    {
        List<Vehicle> GetVehicleListWithCategory();
        List<Vehicle> GetVehicleListWithBrand();
        List<Vehicle> GetVehicleListWithModel();
        List<Vehicle> GetVehicleListWithSeries();

    }
}
