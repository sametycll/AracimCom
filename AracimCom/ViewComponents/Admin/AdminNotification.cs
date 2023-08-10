using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Admin
{
    public class AdminNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
