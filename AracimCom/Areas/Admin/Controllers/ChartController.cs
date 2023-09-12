using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
