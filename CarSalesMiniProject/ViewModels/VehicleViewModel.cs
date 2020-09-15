using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CarSalesMiniProject.Models;
using CarSalesMiniProject.Data;
using Microsoft.IdentityModel.Tokens;

namespace CarSalesMiniProject.ViewModels
{
    public class VehicleViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public bool IsSold { get; set; }
        public DateTime AddDate { get; set; }

        public int Id { get; set; }
    }

    public class CarViewModel: VehicleViewModel
    {
        public string Engine { get; set; }
        public string BodyType { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }

        public CarViewModel(Car car, ICarRepository carRepository)
        {
            this.Engine = car.Engine;
            this.IsSold = car.IsSold;
            this.AddDate = car.AddDate;
            this.Doors = car.Doors;
            this.Wheels = car.Wheels;
            this.Id = car.CarId;
            this.BodyType = carRepository.GetBodyTypeById(car.BodyTypeId).Name;
            this.Make = carRepository.GetMakeById(car.MakeId).Name;
            this.Model = carRepository.GetModelById(car.ModelId).Name;
            this.VehicleType = carRepository.GetVehicleTypeById(car.VehicleTypeId).Name;
        }
    }

    public class CarListViewModel
    {
        public List<CarViewModel> CarList { get; set; }

        public CarListViewModel(ICarRepository carRepository)
        {
            this.CarList = new List<CarViewModel>();
            List<Car> carList = carRepository.GetTop10Cars();
            foreach(Car car in carList)
            {
                this.CarList.Add(new CarViewModel(car, carRepository));
            }  
        }
    }
}
