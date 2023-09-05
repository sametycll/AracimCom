using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
