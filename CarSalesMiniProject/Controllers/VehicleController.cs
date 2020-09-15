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
                return RedirectToAction("ViewVehicle", new { VehicleId = id, JustCreated = true });
            }
            else
            {
                CarCreationViewModel carCreationViewModel = new CarCreationViewModel(_carRepository);
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
                return View();
            }
            else
            {
                car = _carRepository.GetCarById(VehicleId);
                carViewModel = new CarViewModel(car, _carRepository);
                if (carViewModel == null)
                {
                    return View();
;               }
            }

            ViewBag.IdValid = true;
            return View(carViewModel);
        }

        public IActionResult Browse(string vehicleType="")
        {
            CarListViewModel carList = new CarListViewModel(_carRepository);
            return View(carList);
        }
        
        public IActionResult VehicleCreated()
        {
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
