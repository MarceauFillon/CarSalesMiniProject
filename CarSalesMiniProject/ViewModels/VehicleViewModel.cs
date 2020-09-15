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
        public string CreationElapsedTime { get; set; }
        public string GetCreationElapsedTime()
        {
            string stringElapsedTime = String.Empty;
            try
            {
                TimeSpan elapsedTime = DateTime.Now.Subtract(this.AddDate);
                if (elapsedTime.TotalSeconds < 60)
                {
                    stringElapsedTime = "< 1 min ago";
                }
                else if (elapsedTime.TotalHours < 1)
                {
                    stringElapsedTime = String.Format("{0} minutes ago", elapsedTime.Minutes);
                }
                else if (elapsedTime.TotalDays < 1)
                {
                    stringElapsedTime = String.Format("{0} hours ago", elapsedTime.Hours);
                }
                else if (elapsedTime.TotalDays > 1 && elapsedTime.TotalDays < 30)
                {
                    stringElapsedTime = String.Format("{0} days ago", elapsedTime.Days);
                }
                else
                {
                    stringElapsedTime = "> 1 month ago";
                }
            }
            catch
            {
                stringElapsedTime = String.Empty;
            }

            return stringElapsedTime;
        }
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
            this.Doors = car.Doors;
            this.Wheels = car.Wheels;
            this.Id = car.CarId;
            this.BodyType = carRepository.GetBodyTypeById(car.BodyTypeId.GetValueOrDefault()).Name;
            this.Make = carRepository.GetMakeById(car.MakeId.GetValueOrDefault()).Name;
            this.Model = carRepository.GetModelById(car.ModelId.GetValueOrDefault()).Name;
            this.VehicleType = carRepository.GetVehicleTypeById(car.VehicleTypeId.GetValueOrDefault()).Name;
            this.AddDate = car.AddDate;
            this.CreationElapsedTime = GetCreationElapsedTime();
        }
    }

    public class CarListViewModel
    {
        public List<CarViewModel> CarList { get; set; }

        public CarListViewModel(ICarRepository carRepository, int loadMoreFrom = 0)
        {
            if(loadMoreFrom == 0)
            {
                this.CarList = new List<CarViewModel>();
                List<Car> carList = carRepository.GetTop10Cars();
                foreach (Car car in carList)
                {
                    this.CarList.Add(new CarViewModel(car, carRepository));
                }
            }
            else
            {
                this.CarList = new List<CarViewModel>();
                List<Car> carList = carRepository.Get10MoreCars(loadMoreFrom);
                foreach (Car car in carList)
                {
                    this.CarList.Add(new CarViewModel(car, carRepository));
                }
            }
            
        }
    }
}
