using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetListAll().ToPagedList(page, 5); ;
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator(); 
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index","Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }



        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var catValue = cm.GetById(id);
            return View(catValue);
        }


        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            p.CategoryStatus = true;
            cm.TUpdate(p);
            return RedirectToAction("Index", "Category");
        }

        public IActionResult PassiveCategory(int id)
        {
            var x =cm.GetById(id);
            x.CategoryStatus = false;
            cm.TUpdate(x);
            return RedirectToAction("Index", "Category");
        }

        public IActionResult ActiveCategory(int id)
        {
            var x = cm.GetById(id);
            x.CategoryStatus = true;
            cm.TUpdate(x);
            return RedirectToAction("Index", "Category");
        }

    }
}
