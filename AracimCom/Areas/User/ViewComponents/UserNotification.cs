using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.User.ViewComponents
{
    public class UserNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
