using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());     

        public IActionResult Index(int page =1)
        {           
           var values = vm.GetVehicleListWithCategory().ToPagedList(page,5);
            return View(values);
        }
    }
}
