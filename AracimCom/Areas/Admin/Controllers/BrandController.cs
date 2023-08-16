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
    public class BrandController : Controller
    {
        BrandManager bm = new BrandManager(new EfBrandRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());


        public IActionResult Index()
        {
            var values = bm.GetListAll();
            values = bm.GetCategoryForBrand();
            return View(values);
        }



        [HttpGet]
        public IActionResult AddBrand()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(Brand p)
        {

            BrandValidator bv = new BrandValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BrandStatus = true;
                bm.TAdd(p);
                return RedirectToAction("Index", "Brand");
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
        public IActionResult UpdateBrand(int id)
        {
            List<SelectListItem> brandValues = (from x in cm.GetListAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.cv = brandValues;


            var brValue = bm.GetById(id);
            return View(brValue);
        }

        [HttpPost]
        public IActionResult UpdateBrand(Brand p)
        {
            p.BrandStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("Index", "Brand");
        }


        public IActionResult PassiveBrand(int id)
        {
            var x = bm.GetById(id);
            x.BrandStatus = false;
            bm.TUpdate(x);
            return RedirectToAction("Index", "Brand");
        }

        public IActionResult ActiveBrand(int id)
        {
            var x = bm.GetById(id);
            x.BrandStatus = true;
            bm.TUpdate(x);
            return RedirectToAction("Index", "Brand");
        }



    }
}
