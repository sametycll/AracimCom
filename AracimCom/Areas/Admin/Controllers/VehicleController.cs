using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AracimCom.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VehicleController : Controller
    {
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());
        ModelManager mm = new ModelManager(new EfModelRepository());
        SeriesManager sm = new SeriesManager(new EfSeriesRepository());
        BrandManager bm = new BrandManager(new EfBrandRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            //var values = vm.GetListAll();
            //values = vm.GetVehicleListWithModel();
            //values = vm.GetVehicleListWithSeries();
            //values = vm.GetVehicleListWithBrand();
           var values = vm.GetVehicleListWithCategory();
            return View(values);
        }
    }
}
