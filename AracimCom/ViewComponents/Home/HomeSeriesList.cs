using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.ViewComponents.Home
{
	public class HomeSeriesList : ViewComponent
    {
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = sm.LoadBrand(id);
            return View(values);
        }
    }
}
