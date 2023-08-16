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
    public class SeriesController : Controller
    {
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());

        public IActionResult Index()
        {
            var values = sm.GetListAll();
            values = sm.GetBrandForSeries();
           // values = bm.GetCategoryForBrand();
            return View(values);
        }


        [HttpGet]
        public IActionResult AddSeries()
        {
            List<SelectListItem> brandValues = (from x in bm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();
            ViewBag.bv = brandValues;
            return View();

        }

        [HttpPost]
        public IActionResult AddSeries(Series p)
        {
            SeriesValidator sv = new SeriesValidator();
            ValidationResult results = sv.Validate(p);
            if (results.IsValid)
            {
                p.SeriesStatus = true;
                sm.TAdd(p);
                return RedirectToAction("Index", "Series");
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

        [HttpGet]
        public IActionResult UpdateSeries(int id)
        {
            List<SelectListItem> brandValues = (from x in bm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();
            ViewBag.bv = brandValues;


            var srValue = sm.GetById(id);
            return View(srValue);
        }

        [HttpPost]
        public IActionResult UpdateSeries(Series p)
        {
            p.SeriesStatus = true;
            sm.TUpdate(p);
            return RedirectToAction("Index", "Series");
        }


        public IActionResult PassiveSeries(int id)
        {
            var x = sm.GetById(id);
            x.SeriesStatus = false;
            sm.TUpdate(x);
            return RedirectToAction("Index", "Series");
        }

        public IActionResult ActiveSeries(int id)
        {
            var x = sm.GetById(id);
            x.SeriesStatus = true;
            sm.TUpdate(x);
            return RedirectToAction("Index", "Series");
        }



    }
}
