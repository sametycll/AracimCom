using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AracimCom.Areas.User.Controllers
{
    [Area("User")]
    public class MyVehicleController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());
        ModelManager mm = new ModelManager(new EfModelRepository());
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        //[AllowAnonymous]
        public IActionResult Index()
        {
            var values = vm.GetListVehicleWithCategoryUser(1);
            
            return View(values);
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            List<SelectListItem> brandValues = (from x in bm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();

            List<SelectListItem> seriesValues = (from x in sm.GetListAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.SeriesName,
                                                     Value = x.SeriesID.ToString()
                                                 }).ToList();
            List<SelectListItem> modelValues = (from x in mm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.ModelName,
                                                    Value = x.ModelID.ToString()
                                                }).ToList();


            ViewBag.cv = categoryValues;
            ViewBag.bv = brandValues;
            ViewBag.sv = seriesValues;
            ViewBag.mv = modelValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle p)
        {
            VehicleValidator vv = new VehicleValidator();
            ValidationResult results = vv.Validate(p);
            if (results.IsValid)
            {
                p.VehicleStatus = true;
                p.VehicleAdDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                p.VehicleAd = "12345678";
                p.UserID = 1;                
                vm.TAdd(p);
                return RedirectToAction("Index", "MyVehicle");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        //For Cascading brand
        public JsonResult LoadBrand(int id)
        {
            var brand = bm.LoadCategory(id);
            return Json(brand);
        }
        //For Cascading series
        public JsonResult LoadSeries(int id)
        {
            var series = sm.LoadBrand(id);
            return Json(series);
        }
        //For Cascading model
        public JsonResult LoadModel(int id)
        {
            var model = mm.LoadSeries(id);
            return Json(model);
        }

        public IActionResult DetailVehicle(int id) 
        { 
            return View(); 
        }

        public IActionResult DeleteVehicle(int id)
        {
            var vehicleValue = vm.GetById(id);
            vm.TDelete(vehicleValue);
            return RedirectToAction("Index", "MyVehicle");
        }
    }
}
