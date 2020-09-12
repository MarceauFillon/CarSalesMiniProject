using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMiniProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Models.Vehicle vehicle = new Models.Vehicle()
            {
                Make = "Nissan",
                Model = "X-Trail"
            };
            return View(vehicle);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
