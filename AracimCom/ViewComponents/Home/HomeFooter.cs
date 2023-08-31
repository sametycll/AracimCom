using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
    public class HomeFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
