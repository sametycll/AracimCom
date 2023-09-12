using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Admin
{
    public class AdminNotification : ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var value = nm.GetListAll().OrderByDescending(x => x.NotificationID).Take(3).ToList();
            return View(value);
        }
    }
}
