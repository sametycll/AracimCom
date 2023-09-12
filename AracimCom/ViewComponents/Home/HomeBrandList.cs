using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
    public class HomeBrandList : ViewComponent
    {
        BrandManager bm = new BrandManager(new EfBrandRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = bm.LoadCategory(id);
            return View(values);
        }
    }
}
