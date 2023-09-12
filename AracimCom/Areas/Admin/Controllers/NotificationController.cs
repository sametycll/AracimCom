using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
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
    }
}
