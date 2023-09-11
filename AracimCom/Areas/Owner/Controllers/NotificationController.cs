using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace AracimCom.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index(int page = 1)
        {
            var values = nm.GetListAll().ToPagedList(page, 3);
            return View(values);
        }
    }
}
