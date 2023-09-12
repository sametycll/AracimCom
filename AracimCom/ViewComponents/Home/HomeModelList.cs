using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
	public class HomeModelList : ViewComponent
    {
        ModelManager mm = new ModelManager(new EfModelRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = mm.LoadSeries(id);
            return View(values);
        }
    }
}
