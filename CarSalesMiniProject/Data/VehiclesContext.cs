using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using CarSalesMiniProject.Models;

namespace CarSalesMiniProject.Data
{
    public class VehiclesContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }

        public VehiclesContext(DbContextOptions<VehiclesContext> options): base(options)
        {

        }
    }
}