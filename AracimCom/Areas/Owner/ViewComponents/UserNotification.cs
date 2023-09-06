using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Owner.ViewComponents
{
    public class UserNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
