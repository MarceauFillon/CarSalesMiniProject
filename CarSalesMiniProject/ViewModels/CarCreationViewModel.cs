using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using CarSalesMiniProject.Data;
using CarSalesMiniProject.Models;


namespace CarSalesMiniProject.ViewModels
{
    public class CarCreationViewModel
    {
        private readonly ICarRepository _carRepository;
        public IEnumerable<SelectListItem> AllMakes { get; set; }
        public IEnumerable<SelectListItem> AllModels { get; set; }
        public IEnumerable<SelectListItem> AllBodyTypes { get; set; }
        public Car EditableCar { get; set; }

        public CarCreationViewModel()
        {

        }
        public CarCreationViewModel(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
            this.EditableCar = new Car
            {
                VehicleTypeId = carRepository.GetVehicleTypeByName("Car").VehicleTypeId
            };

            this.AllMakes = carRepository.GetAllMakesSelectList();

            this.AllModels = Enumerable.Empty<SelectListItem>();

            this.AllBodyTypes = carRepository.GetAllBodyTypesSelectList();
        }
    }
}
