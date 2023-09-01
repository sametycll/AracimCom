using AracimCom.Models;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AracimCom.Controllers
{
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

        public IActionResult VehicleDetail(int id)
        {
            var car = vm.GetById(id);
            ViewBag.model = vm.GetByModel(id).Model.ModelName;
            ViewBag.series = vm.GetBySeries(id).Model.Series.SeriesName;
            ViewBag.brand = vm.GetByBrand(id).Model.Series.Brand.BrandName;
            ViewBag.userName=vm.GetByUser(id).User.UserName;
            ViewBag.userPhone = vm.GetByUser(id).User.UserPhone;
            return View(car);
        }
    }
}