using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarSalesMiniProject.ViewModels;
using CarSalesMiniProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

using CarSalesMiniProject.Data;

namespace CarSalesMiniProject.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ICarRepository _carRepository;
        public VehicleController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            ViewBag.ActiveNav = "Create";
            return View(new CarCreationViewModel(_carRepository));
        }

        [HttpPost]
        public IActionResult CreateCar(CarCreationViewModel creationViewModel)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                if (creationViewModel.EditableCar.CarId <= 0)
                {
                    creationViewModel.EditableCar.AddDate = DateTime.Now;
                    creationViewModel.EditableCar.IsSold = false;
                    id = _carRepository.InsertCar(creationViewModel.EditableCar);
                }
                ViewBag.ActiveNav = "Browse";
                return RedirectToAction("ViewVehicle", new { VehicleId = id, JustCreated = true });
            }
            else
            {
                CarCreationViewModel carCreationViewModel = new CarCreationViewModel(_carRepository);
                ViewBag.ActiveNav = "Create";
                return base.View(carCreationViewModel);
            }
        }

        public IActionResult ViewVehicle(int VehicleId, bool JustCreated = false)
        {
            Car car = null;
            CarViewModel carViewModel = null;

            ViewBag.IdValid = false;
            ViewBag.JustCreated = JustCreated;

            if (VehicleId <= 0)
            {
                ViewBag.ActiveNav = "Browse";
                return View();
            }
            else
            {
                car = _carRepository.GetCarById(VehicleId);
                carViewModel = new CarViewModel(car, _carRepository);
                if (carViewModel == null)
                {
                    ViewBag.ActiveNav = "Browse";
                    return View();
;               }
            }

            ViewBag.IdValid = true;

            ViewBag.ActiveNav = "Browse";
            return View(carViewModel);
        }

        public IActionResult Browse(string vehicleType="")
        {
            CarListViewModel carList = new CarListViewModel(_carRepository);

            ViewBag.ActiveNav = "Browse";
            return View(carList);
        }
        
        public IActionResult VehicleCreated()
        {
            ViewBag.ActiveNav = "Browse";
            return View();
        }

        [HttpGet]
        public IActionResult GetModels(int makeId)
        {
            if (makeId >= 0)
            {
                IEnumerable<SelectListItem> models = null;

                models = _carRepository.GetModelsSelectListItemsFromMakeId(makeId); 
                
                return Json(new SelectList(models, "Value", "Text"));
            }
            return null;
        }
    }
}
