using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        Message2Manager um = new Message2Manager(new EfMessage2Repository());
        public IActionResult Index(int page = 1)
        {
            var values = um.GetListAll().OrderByDescending(x => x.MessageID).ToPagedList(page, 5);
            return View(values);
        }
    }
}
