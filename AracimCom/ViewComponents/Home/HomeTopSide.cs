using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
    public class HomeTopSide:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
