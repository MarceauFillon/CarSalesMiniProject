using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using CarSalesMiniProject.Models;

namespace CarSalesMiniProject.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        protected readonly VehiclesContext _database_context;

        public VehicleRepository(VehiclesContext database_context)
        {
            _database_context = database_context;
        }

        public IEnumerable<SelectListItem> GetModelSelectListItemsFromMakeId(int makeId)
        {
            return _database_context.Models.Where(m => m.MakeId == makeId).OrderBy(m => m.Name).Select(m =>
                    new SelectListItem
                    {
                        Value = m.ModelId.ToString(),
                        Text = m.Name,
                    }).ToList();
        }

        public string GetModelNameById(int id)
        {
           return _database_context.Models.Find(id).Name;
        }
        public string GetMakeNameById(int id)
        {
            return _database_context.Makes.Find(id).Name;
        }

        public string GetVehicleTypeNameById(int id)
        {
            return _database_context.VehicleTypes.Find(id).Name;
        }

    }
    public class CarRepository : VehicleRepository, ICarRepository
    {
        public CarRepository(VehiclesContext database_context) : base(database_context) { }
        public int InsertCar(Car car)
        {
            _database_context.Cars.Add(car);
            _database_context.SaveChanges();

            return car.CarId;
        }
        public Car GetCarById(int id)
        {
            return _database_context.Cars.Find(id);
        }

        public string GetBodyTypeNameById(int id)
        {
            return _database_context.BodyTypes.Find(id).Name;
        }

        public List<Car> GetTop10Cars()
        {
            return _database_context.Cars.OrderBy(c => c.AddDate).Take(10).ToList();
        }
    } 
}
