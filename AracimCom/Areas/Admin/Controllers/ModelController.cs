using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        ModelManager mm = new ModelManager(new EfModelRepository());
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            //var values = mm.GetListAll();
            //values = mm.GetListModelWithSeries();
            //values = mm.GetListModelWithBrand();
            var values = mm.GetListModelWithCategory();


            return View(values);
        }

        [HttpGet]
        public IActionResult AddModel()
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


            ViewBag.cv = categoryValues;
            ViewBag.bv = brandValues;
            ViewBag.sv = seriesValues;

            return View();

        }

        [HttpPost]
        public IActionResult AddModel(Model p)
        {
            ModelValidator mv = new ModelValidator();
            ValidationResult results = mv.Validate(p);
            if (results.IsValid)
            {
                p.ModelStatus = true;
                mm.TAdd(p);
                return RedirectToAction("Index", "Model");
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


        [HttpGet]
        public IActionResult UpdateModel(int id)
        {
            List<SelectListItem> seriesValues = (from x in sm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.SeriesName,
                                                    Value = x.SeriesID.ToString()
                                                }).ToList();
            ViewBag.sv = seriesValues;


            var mmValue = mm.GetById(id);
            return View(mmValue);
        }

        [HttpPost]
        public IActionResult UpdateModel(Model p)
        {
            p.ModelStatus = true;
            mm.TUpdate(p);
            return RedirectToAction("Index", "Model");
        }


        public IActionResult PassiveModel(int id)
        {
            var x = mm.GetById(id);
            x.ModelStatus = false;
            mm.TUpdate(x);
            return RedirectToAction("Index", "Model");
        }

        public IActionResult ActiveModel(int id)
        {
            var x = mm.GetById(id);
            x.ModelStatus = true;
            mm.TUpdate(x);
            return RedirectToAction("Index", "Model");
        }




    }
}
