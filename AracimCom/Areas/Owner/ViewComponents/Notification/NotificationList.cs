using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Owner.ViewComponents.Notification
{
    public class NotificationList:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetListAll();
            return View(values);
        }
    }
}
