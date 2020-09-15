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
        IEnumerable<SelectListItem> GetModelSelectListItemsFromMakeId(int id);
        string GetModelNameById(int id);
        string GetMakeNameById(int id);
        string GetVehicleTypeNameById(int id);
    }
    public interface ICarRepository : IVehicleRepository
    {
        int InsertCar(Car car);
        Car GetCarById(int id);

        string GetBodyTypeNameById(int id);

        List<Car> GetTop10Cars();
    }
}
