using BusinessLayer.Concreate;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AracimCom.Areas.Owner.ViewComponents
{
    public class UserMessageNotification : ViewComponent
    {
        UserManager um = new UserManager(new EfUserRepository());
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var _userID = c.Users.Where(x => x.UserMail == userMail).Select(y => y.UserID).FirstOrDefault();
            var id = um.GetById(_userID).UserID;
            
            var values = mm.GetInboxListByUser(id);
            return View(values);
        }
    }
}
