using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using CarSalesMiniProject.Models;
using System.Linq.Expressions;

namespace CarSalesMiniProject.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        protected readonly VehiclesContext _databaseContext;

        public VehicleRepository(VehiclesContext database_context)
        {
            _databaseContext = database_context;
        }

        public IEnumerable<SelectListItem> GetModelsSelectListItemsFromMakeId(int makeId)
        {
            return _databaseContext.Models.Where(m => m.MakeId == makeId).OrderBy(m => m.Name).Select(m =>
                    new SelectListItem
                    {
                        Value = m.ModelId.ToString(),
                        Text = m.Name,
                    }).ToList();
        }

        public Model GetModelById(int id)
        {
            return _databaseContext.Models.Find(id);
        }

        public Make GetMakeById(int id)
        {
            return _databaseContext.Makes.Find(id);
        }

        public IEnumerable<SelectListItem> GetAllMakesSelectList()
        {
            return _databaseContext.Makes.OrderBy(m => m.Name).Select(m =>
                        new SelectListItem
                        {
                            Value = m.MakeId.ToString(),
                            Text = m.Name
                        }).ToList();
        }

        public VehicleType GetVehicleTypeById(int id)
        {
            return _databaseContext.VehicleTypes.Find(id);
        }

        public VehicleType GetVehicleTypeByName(string name)
        {
            return _databaseContext.VehicleTypes.Where(v => v.Name == name).FirstOrDefault();
        }

    }
    public class CarRepository : VehicleRepository, ICarRepository
    {
        public CarRepository(VehiclesContext database_context) : base(database_context) { }
        public int InsertCar(Car car)
        {
            try
            {
                _databaseContext.Cars.Add(car);
                _databaseContext.SaveChanges();

                return car.CarId;
            }
            catch
            {
                return 0;
            }
            
        }
        public Car GetCarById(int id)
        {
            return _databaseContext.Cars.Find(id);
        }

        public BodyType GetBodyTypeById(int id)
        {
            return _databaseContext.BodyTypes.Find(id);
        }

        public List<Car> GetTop10Cars()
        {
            return _databaseContext.Cars.OrderBy(c => c.AddDate).Take(10).ToList();
        }

        public IEnumerable<SelectListItem> GetAllBodyTypesSelectList()
        {
            return _databaseContext.BodyTypes.OrderBy(b => b.Name).Select(b =>
                        new SelectListItem
                        {
                            Value = b.BodyTypeId.ToString(),
                            Text = b.Name,
                        }).ToList();
        }

        public List<Car> Get10MoreCars(int carsToSkip)
        {
            return _databaseContext.Cars.OrderBy(c => c.AddDate).Skip(carsToSkip).Take(10).ToList();
        }
    } 
}
