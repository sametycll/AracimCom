using BusinessLayer.Concreate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public IActionResult Index(int page = 1)
        {
            var values = mm.GetListMessageAllWithUsers().OrderByDescending(x => x.MessageID).ToPagedList(page, 5);
            return View(values);
        }

        public IActionResult PassiveMessage(int id)
        {
            var x = mm.GetById(id);
            x.MessageStatus = false;
            mm.TUpdate(x);
            return RedirectToAction("Index", "Message");
        }

        public IActionResult ActiveMessage(int id)
        {
            var x = mm.GetById(id);
            x.MessageStatus = true;
            mm.TUpdate(x);
            return RedirectToAction("Index", "Message");
        }

        public IActionResult DeleteMessage(int id)
        {
            var messageValue = mm.GetById(id);
            mm.TDelete(messageValue);
            return RedirectToAction("Index", "Message");
        }
    }
}
