using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {
        Context c = new Context();
        [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.category = c.Categories.Count();
            ViewBag.brand=c.Brands.Count();
            ViewBag.series = c.Seriess.Count();
            ViewBag.model = c.Models.Count();
            ViewBag.vehicle = c.Vehicles.Count();
            ViewBag.user = c.Users.Count();
            ViewBag.message = c.Message2s.Count();
            ViewBag.notification = c.Notifications.Count();
            return View();
        }
    }
}
