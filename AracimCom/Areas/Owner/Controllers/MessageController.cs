using BusinessLayer.Concreate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace AracimCom.Areas.Owner.Controllers
{
    [Area("Owner")]
    public class MessageController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var userMail = User.Identity.Name;
            var _userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var id = um.GetById(_userID).UserID;            
            var values = mm.GetInboxListByUser(id).ToPagedList(page, 5);
            return View(values);
        }

        public IActionResult DetailMessage(int id)
        {
            var value = mm.GetInboxByUserID(id);
            return View(value);
        }
    }
}
