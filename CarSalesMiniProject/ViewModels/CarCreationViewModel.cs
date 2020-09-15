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
        public IEnumerable<SelectListItem> AllVehicleTypes { get; set; }
        public IEnumerable<SelectListItem> AllMakes { get; set; }
        public IEnumerable<SelectListItem> AllModels { get; set; }
        public IEnumerable<SelectListItem> AllBodyTypes { get; set; }
        public Car EditableCar { get; set; }

        public CarCreationViewModel()
        {
            using var db = new VehiclesContext();

            this.EditableCar = new Car();
            this.EditableCar.VehicleTypeId = db.VehicleTypes.Where(v =>
                v.Name == "car").ToList()[0].VehicleTypeId;

            this.AllVehicleTypes = db.VehicleTypes.OrderBy(v => v.Name).Select(v =>
                        new SelectListItem
                        {
                            Value = v.VehicleTypeId.ToString(),
                            Text = v.Name
                        }).ToList();

            this.AllMakes = db.Makes.OrderBy(m => m.Name).Select(m =>
                        new SelectListItem
                        {
                            Value = m.MakeId.ToString(),
                            Text = m.Name
                        }).ToList();

            this.AllModels = Enumerable.Empty<SelectListItem>();

            this.AllBodyTypes = db.BodyTypes.OrderBy(b => b.Name).Select(b =>
                        new SelectListItem
                        {
                            Value = b.BodyTypeId.ToString(),
                            Text = b.Name,
                        }).ToList();
        }
    }
}
