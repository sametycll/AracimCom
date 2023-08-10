using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminNavbarPartical()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartical()
        {
            return PartialView();
        }
    }
}
