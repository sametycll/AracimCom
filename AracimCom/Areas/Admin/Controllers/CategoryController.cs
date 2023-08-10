using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
