using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AracimCom.ViewComponents.Admin
{
    public class AdminMessageNotification:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            var value = mm.GetListMessageAllWithUsers().OrderByDescending(x => x.MessageID).Take(3).ToList();
            return View(value);
        }
    }
}
