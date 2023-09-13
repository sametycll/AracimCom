using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AracimCom.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());
        public IActionResult Index(int id, int page = 1)
        {
            ViewBag.Id = id;    
            var values = vm.GetListVehicleWithCategoryUser(id).ToPagedList(page, 10); ;
            return View(values);
        }
    }
}
