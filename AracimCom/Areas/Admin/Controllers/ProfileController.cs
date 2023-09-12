using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        ManagerManager mm = new ManagerManager(new EfManagerRepository());
        Context c = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            //var userName = User.Identity.Name;
            //var _managerID = c.Managers.Where(x => x.Username == userName).Select(y => y.ManagerID).FirstOrDefault();
            //var id = mm.GetById(_managerID).ManagerID;
            var managerValues = mm.GetById(1);
            return View(managerValues);
        }


        [HttpPost]
        public IActionResult Index(Manager p)
        {
            ManagerValidator mv = new ManagerValidator();
            ValidationResult results = mv.Validate(p);
            if (results.IsValid)
            {               
                mm.TUpdate(p);
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
