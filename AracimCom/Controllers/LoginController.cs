using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
