using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.User
{
    public class UserDetails : ViewComponent
    {
        UserManager um = new UserManager(new EfUserRepository());
        public IViewComponentResult Invoke(int id)
        {            
            var values = um.GetById(id);
            return View(values);
        }
    }
}
