using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
    public class HomeCategoryList : ViewComponent
    {
        CategoryManager cm =new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetListAll();
            return View(values);
        }
    }
}
