using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
            string api = "ed7e4ffd1577e625d9215150e74d5298";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document= XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
 