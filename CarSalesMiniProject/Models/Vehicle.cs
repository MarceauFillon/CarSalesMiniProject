using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesMiniProject.Models
{
    public class Vehicle
    {
        [Required(ErrorMessage = "Please Select a Make")]
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Please Select a Model")]
        public int ModelId { get; set; }
        public int VehicleTypeId { get; set; }
        public bool IsSold { get; set; }
        public DateTime AddDate { get; set; }
    }

    public class Car : Vehicle
    {
        public int CarId {get; set;}
        [Required(ErrorMessage = "Please specify the engine")]
        [StringLength(50)]
        public string Engine { get; set; }
        [Required(ErrorMessage = "Please Select a Body Type")]
        public int BodyTypeId { get; set; }
        [Required]
        [Range(1, 9,
            ErrorMessage = "Please select a number of doors between 1 and 9.")]
        public int Doors { get; set; }
        [Required]
        [Range(1, 9, 
            ErrorMessage = "Please select a number of wheels between 1 and 9.")]
        public int Wheels { get; set; }
    }
}
