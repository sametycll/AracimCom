using AracimCom.Models;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AracimCom.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());
        ModelManager mm = new ModelManager(new EfModelRepository());
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());       

        public IActionResult Index()
        {
            var values = vm.GetListAll();

            return View(values);
        }             

        public IActionResult DetailVehicle(int id)
        {
            return View(vm.GetByIdWithCt(id));
        }


    }
}