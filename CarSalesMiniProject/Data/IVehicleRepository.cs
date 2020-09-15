using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using CarSalesMiniProject.Models;

namespace CarSalesMiniProject.Data
{
    public interface IVehicleRepository
    {
        IEnumerable<SelectListItem> GetModelsSelectListItemsFromMakeId(int id);
        Model GetModelById(int id);
        Make GetMakeById(int id);
        IEnumerable<SelectListItem> GetAllMakesSelectList();
        VehicleType GetVehicleTypeById(int id);
        VehicleType GetVehicleTypeByName(string name);
    }

    public interface ICarRepository : IVehicleRepository
    {
        int InsertCar(Car car);
        Car GetCarById(int id);

        BodyType GetBodyTypeById(int id);

        List<Car> GetTop10Cars();
        IEnumerable<SelectListItem> GetAllBodyTypesSelectList();
    }
}
