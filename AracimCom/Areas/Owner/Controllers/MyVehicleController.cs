using AracimCom.Areas.Owner.Models;
using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AracimCom.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class MyVehicleController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());
        ModelManager mm = new ModelManager(new EfModelRepository());
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c=new Context();
        //[AllowAnonymous]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var _userID=c.Users.Where(x=>x.UserMail==userMail).Select(y=>y.UserID).FirstOrDefault();
            var values=vm.GetListVehicleWithCategoryUser(_userID);
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
        public IActionResult AddVehicle(AddVehicleImage p)
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

            Vehicle v = new Vehicle();
            AddVehicleImage avi = new AddVehicleImage();
            if (p.VehicleImage != null && p.VehicleThumbnailImage != null)
            {
                v.VehicleImage = avi.ImageAdd(p.VehicleImage);
                v.VehicleThumbnailImage = avi.ThumbNailImageAdd(p.VehicleThumbnailImage);
                v.VehicleTitle = p.VehicleTitle;
                v.VehicleDescription = p.VehicleDescription;
                v.VehiclePrice = p.VehiclePrice;
                v.VehicleYear = p.VehicleYear;
                v.VehicleKm = p.VehicleKm;
                v.VehicleFuel = p.VehicleFuel;
                v.VehicleGear = p.VehicleGear;
                v.VehicleBodyType = p.VehicleBodyType;
                v.VehicleEnginePower = p.VehicleEnginePower;
                v.VehicleEngineCapacity = p.VehicleEngineCapacity;
                v.VehicleWheelDrive = p.VehicleWheelDrive;
                v.VehicleColor = p.VehicleColor;
                v.VehicleWarranty = p.VehicleWarranty;
                v.VehicleFrom = p.VehicleFrom;
                v.VehicleExcangeable = p.VehicleExcangeable;
                v.VehicleCity = p.VehicleCity;
                v.VehicleDistrict = p.VehicleDistrict;
                v.VehicleAd = "12345678";
                v.VehicleAdDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                v.VehicleStatus = true;
                var userMail = User.Identity.Name;
                var _userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
                var values = um.GetById(_userID).UserID;
                v.UserID = values;
                v.ModelID = p.ModelID;
                vm.TAdd(v);
                return RedirectToAction("Index", "MyVehicle");
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
            var detailValue = vm.GetById(id);
            ViewBag.model = vm.GetByModel(id).Model.ModelName;
            ViewBag.series = vm.GetBySeries(id).Model.Series.SeriesName;
            ViewBag.brand = vm.GetByBrand(id).Model.Series.Brand.BrandName;
            ViewBag.category = vm.GetByCategory(id).Model.Series.Brand.Category.CategoryName;
            return View(detailValue);
        }

        [HttpGet]
        public IActionResult UpdateVehicle(int id)
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
            var values = vm.GetById(id);
            return View(values);
        }
             
        [HttpPost]
        public IActionResult UpdateVehicle(AddVehicleImage p)
        {
            List<SelectListItem> modelValues = (from x in mm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.ModelName,
                                                    Value = x.ModelID.ToString()
                                                }).ToList();
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

            ViewBag.cv = categoryValues;
            ViewBag.bv = brandValues;
            ViewBag.sv = seriesValues;
            ViewBag.mv = modelValues;

            var oldVhID = p.VehicleID;
            var oldVh = vm.GetById(oldVhID);
            var newVh = oldVh;
            Vehicle v = new Vehicle();
            
            AddVehicleImage imageAdd = new AddVehicleImage();

            if (p.VehicleImage == null && p.VehicleThumbnailImage == null)
            {
                newVh.VehicleImage = oldVh.VehicleImage;
                newVh.VehicleThumbnailImage = oldVh.VehicleThumbnailImage;
            }
            else if (p.VehicleImage == null)
            {
                newVh.VehicleImage = oldVh.VehicleImage;
                newVh.VehicleThumbnailImage = imageAdd.ThumbNailImageAdd(p.VehicleThumbnailImage);

            }
            else if (p.VehicleThumbnailImage == null)
            {
                newVh.VehicleImage = imageAdd.ImageAdd(p.VehicleImage);
                newVh.VehicleThumbnailImage = oldVh.VehicleThumbnailImage;                
            }
            else
            {
                newVh.VehicleImage = imageAdd.ImageAdd(p.VehicleImage);
                newVh.VehicleThumbnailImage = imageAdd.ThumbNailImageAdd(p.VehicleThumbnailImage);
            }

            newVh.VehicleTitle = p.VehicleTitle;
            newVh.VehicleDescription = p.VehicleDescription;
            newVh.VehiclePrice = p.VehiclePrice;
            newVh.VehicleYear = p.VehicleYear;
            newVh.VehicleKm = p.VehicleKm;
            newVh.VehicleFuel = p.VehicleFuel;
            newVh.VehicleGear = p.VehicleGear;
            newVh.VehicleBodyType = p.VehicleBodyType;
            newVh.VehicleEnginePower = p.VehicleEnginePower;
            newVh.VehicleEngineCapacity = p.VehicleEngineCapacity;
            newVh.VehicleWheelDrive = p.VehicleWheelDrive;
            newVh.VehicleColor = p.VehicleColor;
            newVh.VehicleWarranty = p.VehicleWarranty;
            newVh.VehicleFrom = p.VehicleFrom;
            newVh.VehicleExcangeable = p.VehicleExcangeable;
            newVh.VehicleCity = p.VehicleCity;
            newVh.VehicleDistrict = p.VehicleDistrict;
            newVh.VehicleAd = "12345678";
            newVh.VehicleAdDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            newVh.VehicleStatus = true;
            var userMail = User.Identity.Name;
            var _userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var values = um.GetById(_userID).UserID;
            newVh.UserID =values;
            newVh.ModelID = p.ModelID;
           // newVh.VehicleID = oldVh.VehicleID;
            vm.TUpdate(newVh);
            return RedirectToAction("Index", "MyVehicle");
        }


        public IActionResult DeleteVehicle(int id)
        {
            var vehicleValue = vm.GetById(id);
            vm.TDelete(vehicleValue);
            return RedirectToAction("Index", "MyVehicle");
        }



    }


}
