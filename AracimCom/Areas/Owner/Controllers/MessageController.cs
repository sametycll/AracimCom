using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult Index()
        {
            int id = 1;
            var values = mm.GetInboxListByUser(id);
            return View(values);
        }
        public IActionResult DetailMessage(int id)
        {
            var value = mm.GetInboxByUserID(id);
            return View(value);
        }
    }
}
