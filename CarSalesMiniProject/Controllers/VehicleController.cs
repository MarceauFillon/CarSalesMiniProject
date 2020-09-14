using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarSalesMiniProject.ViewModels;
using CarSalesMiniProject.Models;

using CarSalesMiniProject.Helpers;

namespace CarSalesMiniProject.Controllers
{
    public class VehicleController : Controller
    {
        [HttpGet]
        public IActionResult CreateCar()
        {
            return View(new CarCreationViewModel());
        }

        [HttpPost]
        public IActionResult CreateCar(CarCreationViewModel creationViewModel)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                using (var db = new VehiclesContext())
                {
                    if (creationViewModel.EditableCar.CarId <= 0)
                    {
                        creationViewModel.EditableCar.AddDate = DateTime.Now;
                        creationViewModel.EditableCar.IsSold = false;
                        db.Cars.Add(creationViewModel.EditableCar);
                        db.SaveChanges();
                        id = creationViewModel.EditableCar.CarId;
                    }
                }
                return RedirectToAction("ViewVehicle", new { VehicleId = id, JustCreated = true });
            }
            else
                return View(new CarCreationViewModel());
        }

        public IActionResult ViewVehicle(int VehicleId, bool JustCreated = false)
        {
            VehicleViewModel vehicle = null;

            ViewBag.IdValid = false;
            ViewBag.JustCreated = JustCreated;

            using (var db = new VehiclesContext())
            {
                if (VehicleId <= 0)
                {
                    return View();
                }
                else
                {
                    vehicle = new CarViewModel(db.Cars.FirstOrDefault(v => v.CarId == VehicleId));
                    if (vehicle == null)
                    {
                        return View();
;                   }
                }
            }

            ViewBag.IdValid = true;
            return View(vehicle);
        }

        public IActionResult Browse(string vehicleType="")
        {
            CarListViewModel carList = new CarListViewModel();
            return View(carList);
        }
        
        public IActionResult VehicleCreated()
        {
            return View();
        }
    }
}
