using AracimCom.Models;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using X.PagedList;

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

        public IActionResult Index(int page = 1)
        {
            var values = vm.GetListAll().ToPagedList(page, 8);

            return View(values);
        }             

        public IActionResult DetailVehicle(int id)
        {
            return View(vm.GetByIdWithCt(id));
        }


    }
}