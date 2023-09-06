using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class ProfileController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());

        [HttpGet]
        public IActionResult Index()
        {
            var userValues = um.GetById(1);
            return View(userValues);
        }


        [HttpPost]
        public IActionResult Index(User p)
        {
            UserValidator uv = new UserValidator();
            ValidationResult results = uv.Validate(p);
            if (results.IsValid)
            {
                p.UserStatus = true;                
                um.TUpdate(p);
                return RedirectToAction("Index", "Profile");
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
    }
}
