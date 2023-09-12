using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1)
        {
            var values = um.GetListAll().OrderByDescending(x=>x.UserID).ToPagedList(page, 5);
            return View(values);
        }


        [HttpGet]
        public IActionResult AddUser()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User p)
        {

            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(p);
            if (results.IsValid)
            {
                p.UserStatus = true;
                um.TAdd(p);
                return RedirectToAction("Index", "Users");
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
        public IActionResult UpdateUser(int id)
        {
            var value = um.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateUser(User p)
        {
            p.UserStatus = true;
            um.TUpdate(p);
            return RedirectToAction("Index", "Users");
        }


        public IActionResult PassiveUser(int id)
        {
            var x = um.GetById(id);
            x.UserStatus = false;
            um.TUpdate(x);
            return RedirectToAction("Index", "Users");
        }

        public IActionResult ActiveUser(int id)
        {
            var x = um.GetById(id);
            x.UserStatus = true;
            um.TUpdate(x);
            return RedirectToAction("Index", "Users");
        }
    }
}
