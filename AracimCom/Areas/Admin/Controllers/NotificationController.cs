using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index(int page = 1)
        {
            var values = nm.GetListAll().OrderByDescending(x => x.NotificationID).ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotification(Notification p)
        {

            NotificationValidator nv = new NotificationValidator();
            ValidationResult results = nv.Validate(p);
            if (results.IsValid)
            {
                if (p.NotificationTypeSymbol == null && p.NotificationColor == null)
                {
                    p.NotificationTypeSymbol = "fas fa-file ";
                    p.NotificationColor = "blue";

                }
                else if (p.NotificationTypeSymbol == null)
                {
                    p.NotificationTypeSymbol = "fas fa-file ";

                }
                else if (p.NotificationColor == null)
                {
                    p.NotificationColor = "blue";
                }

                p.NotificationStatus = true;
                p.NotificationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                nm.TAdd(p);
                return RedirectToAction("Index", "Notification");
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
        public IActionResult UpdateNotification(int id)
        {
            var value = nm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateNotification(Notification p)
        {
            if (p.NotificationTypeSymbol == null && p.NotificationColor == null)
            {
                p.NotificationTypeSymbol = "fas fa-file ";
                p.NotificationColor = "blue";

            }
            else if (p.NotificationTypeSymbol == null)
            {
                p.NotificationTypeSymbol = "fas fa-file ";

            }
            else if (p.NotificationColor == null)
            {
                p.NotificationColor = "blue";
            }

            p.NotificationStatus = true;
            p.NotificationDate = DateTime.Parse(DateTime.Now.ToShortDateString());           
            nm.TUpdate(p);
            return RedirectToAction("Index", "Notification");
        }


        public IActionResult PassiveNotification(int id)
        {
            var x = nm.GetById(id);
            x.NotificationStatus = false;
            nm.TUpdate(x);
            return RedirectToAction("Index", "Notification");
        }

        public IActionResult ActiveNotification(int id)
        {
            var x = nm.GetById(id);
            x.NotificationStatus = true;
            nm.TUpdate(x);
            return RedirectToAction("Index", "Notification");
        }

        public IActionResult DeleteNotification(int id)
        {
            var notificationValue = nm.GetById(id);
            nm.TDelete(notificationValue);
            return RedirectToAction("Index", "Notification");
        }

    }
}
