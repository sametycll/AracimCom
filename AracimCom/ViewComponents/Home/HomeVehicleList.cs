using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
	public class HomeVehicleList : ViewComponent
    {
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = vm.GetVehicleListWithModel(id).FirstOrDefault();
            return View(values);
        }
    }
}
