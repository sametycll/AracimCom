using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            var values = nm.GetListAll();
            return View(values);
        }
    }
}
