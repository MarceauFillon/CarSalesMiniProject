using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CarSalesMiniProject.Models;
using CarSalesMiniProject.Helpers;

namespace CarSalesMiniProject.ViewModels
{
    public class VehicleViewModel
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleType { get; set; }
        public bool IsSold { get; set; }
        public DateTime AddDate { get; set; }
    }

    public class CarViewModel: VehicleViewModel
    {
        public string Engine { get; set; }
        public string BodyType { get; set; }
        public int Doors { get; set; }
        public int Wheels { get; set; }

        public CarViewModel(Car car)
        {
            this.Engine = car.Engine;
            this.IsSold = car.IsSold;
            this.AddDate = car.AddDate;
            this.Doors = car.Doors;
            this.Wheels = car.Wheels;

            using var db = new VehiclesContext();
            {
                this.BodyType = db.BodyTypes.Where(b => b.BodyTypeId == car.BodyTypeId).FirstOrDefault().Name;
                this.Make = db.Makes.Where(m => m.MakeId == car.MakeId).FirstOrDefault().Name;
                this.Model = db.Models.Where(m => m.ModelId == car.ModelId).FirstOrDefault().Name;
                this.VehicleType = db.VehicleTypes.Where(v => v.VehicleTypeId == car.VehicleTypeId).FirstOrDefault().Name;
            }
        }
    }

    public class CarListViewModel
    {
        public List<CarViewModel> CarList { get; set; }

        public CarListViewModel()
        {
            this.CarList = new List<CarViewModel>();
            using var db = new VehiclesContext();
            {
                List<Car> carList = db.Cars.OrderBy(c => c.AddDate).Take(10).ToList();
                foreach(Car car in carList)
                {
                    this.CarList.Add(new CarViewModel(car));
                }
            }
            
        }
    }
}
