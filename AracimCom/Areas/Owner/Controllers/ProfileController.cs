using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
        Context c = new Context();
        [HttpGet]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var _userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var id = um.GetById(_userID).UserID;
            var userValues = um.GetById(id);
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
