using AracimCom.Models;
using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AracimCom.Controllers
{
    public class HomeController : Controller
    {
        VehicleManager vm = new VehicleManager(new EfVehicleRepository());

        public IActionResult index()
        {
            var values = vm.GetListAll();

            return View(values);
        }
    }
}