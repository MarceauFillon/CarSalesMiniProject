using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMiniProject.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Create(string vehicleType="")
        {
            return View();
        }

        public IActionResult Browse(string vehicleType="")
        {
            return View();
        }
    }
}
