using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Rendering;

using CarSalesMiniProject.Data;
using CarSalesMiniProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesTestMiniProject
{
    public class ModelsFixture : IDisposable
    {
        public DbContextOptions<VehiclesContext> options;
        public ModelsFixture()
        {
            options = new DbContextOptionsBuilder<VehiclesContext>()
            .UseInMemoryDatabase(databaseName: "ModelsDataBase")
            .Options;

            using var vehicleContext = new VehiclesContext(options);
            vehicleContext.Models.Add(new Model
            {
                ModelId = 1,
                MakeId = 1,
                Name = "X-Trail"
            });

            vehicleContext.Models.Add(new Model
            {
                ModelId = 2,
                MakeId = 1,
                Name = "Pathfinder"
            });

            vehicleContext.Models.Add(new Model
            {
                ModelId = 3,
                MakeId = 2,
                Name = "Cherokee"
            });
            vehicleContext.SaveChanges();
        }
        public void Dispose()
        {
            using var vehiclesContext = new VehiclesContext(options);
            vehiclesContext.Database.EnsureDeleted();
        }
    }

    public class MakesFixture : IDisposable
    {
        public DbContextOptions<VehiclesContext> options;
        public MakesFixture()
        {
            options = new DbContextOptionsBuilder<VehiclesContext>()
            .UseInMemoryDatabase(databaseName: "MakesDataBase")
            .Options;

            using var vehicleContext = new VehiclesContext(options);
            vehicleContext.Makes.Add(new Make
            {
                MakeId = 1,
                Name = "Nissan"
            });

            vehicleContext.Makes.Add(new Make
            {
                MakeId = 2,
                Name = "Jeep"
            });

            vehicleContext.SaveChanges();

        }
        public void Dispose()
        {
            using var vehiclesContext = new VehiclesContext(options);
            vehiclesContext.Database.EnsureDeleted();
        }
    }

    public class VehicleTypesFixture : IDisposable
    {
        public DbContextOptions<VehiclesContext> options;
        public VehicleTypesFixture()
        {
            options = new DbContextOptionsBuilder<VehiclesContext>()
            .UseInMemoryDatabase(databaseName: "VehicleTypesDataBase")
            .Options;

            using var vehicleContext = new VehiclesContext(options);
            vehicleContext.VehicleTypes.Add(new VehicleType
            {
                VehicleTypeId = 1,
                Name = "Car"
            });

            vehicleContext.VehicleTypes.Add(new VehicleType
            {
                VehicleTypeId = 2,
                Name = "Boat"
            });

            vehicleContext.SaveChanges();

        }
        public void Dispose()
        {
            using var vehiclesContext = new VehiclesContext(options);
            vehiclesContext.Database.EnsureDeleted();
        }
    }

    public class BodyTypesFixture : IDisposable
    {
        public DbContextOptions<VehiclesContext> options;
        public BodyTypesFixture()
        {
            options = new DbContextOptionsBuilder<VehiclesContext>()
            .UseInMemoryDatabase(databaseName: "BodyTypesDataBase")
            .Options;

            using var vehicleContext = new VehiclesContext(options);
            vehicleContext.BodyTypes.Add(new BodyType
            {
                BodyTypeId = 1,
                Name = "Wagon"
            });

            vehicleContext.BodyTypes.Add(new BodyType
            {
                BodyTypeId = 2,
                Name = "SUV"
            });

            vehicleContext.SaveChanges();
        }

        public void Dispose()
        {
            using var vehiclesContext = new VehiclesContext(options);
            vehiclesContext.Database.EnsureDeleted();
        }
    }

    public class CarsFixture : IDisposable
    {
        public DbContextOptions<VehiclesContext> options;
        public CarsFixture()
        {
            options = new DbContextOptionsBuilder<VehiclesContext>()
            .UseInMemoryDatabase(databaseName: "CarsDataBase")
            .Options;

            using var vehicleContext = new VehiclesContext(options);
            for (int i = 0; i < 12; i += 2)
            {
                vehicleContext.Cars.Add(new Car
                {
                    CarId = i+1,
                    MakeId = 1,
                    Engine = "v6",
                    Doors = 4,
                    Wheels = 4,
                    BodyTypeId = 1,
                    ModelId = 1,
                    AddDate = DateTime.Today,
                    IsSold = false,
                    VehicleTypeId = 1
                });

                vehicleContext.Cars.Add(new Car
                {
                    CarId = i+2,
                    MakeId = 1,
                    Engine = "v4",
                    Doors = 4,
                    Wheels = 4,
                    BodyTypeId = 2,
                    ModelId = 3,
                    AddDate = DateTime.Today,
                    IsSold = false,
                    VehicleTypeId = 1
                });
            }
            

            vehicleContext.SaveChanges();
        }
        public void Dispose()
        {
            using var vehiclesContext = new VehiclesContext(options);
            vehiclesContext.Database.EnsureDeleted();
        }
    }

    [Collection("Models")]
    public class TestCarRepositoryGetModels : IClassFixture<ModelsFixture>
    {
        private readonly ModelsFixture _fixture; 
        public TestCarRepositoryGetModels(ModelsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetModels with MakeId = 0")]
        public void TestGetModelsMakeIdZero()
        {

            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                IEnumerable<SelectListItem> models = carRepository.GetModelsSelectListItemsFromMakeId(0);
                Assert.Equal(Enumerable.Empty<SelectListItem>(), models);
            }
        }

        [Fact(DisplayName = "Test GetModels with MakeId < 0")]
        public void TestGetModelsMakeIdNegative()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                IEnumerable<SelectListItem> models = carRepository.GetModelsSelectListItemsFromMakeId(-1);
                Assert.Equal(Enumerable.Empty<SelectListItem>(), models);
            }
        }

        [Fact(DisplayName = "Test GetModels with valid MakeId")]
        public void TestGetModelsMakeIdValid()
        {
            SelectListItem xTrailItem = new SelectListItem { Value = "1",
                Text = "X-Trail" };
            SelectListItem pathfinderItem = new SelectListItem
            {
                Value = "2",
                Text = "Pathfinder"
            };
            List<SelectListItem> validModelsList = new List<SelectListItem>(){
                pathfinderItem,
                xTrailItem
            };

                using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                List<SelectListItem> models = carRepository.GetModelsSelectListItemsFromMakeId(1).ToList();
                Assert.Equal(2, models.Count());
                int indexItem = 0;
                foreach(SelectListItem item in validModelsList)
                {
                    Assert.Equal(validModelsList[indexItem].Value, models[indexItem].Value);
                    Assert.Equal(validModelsList[indexItem].Text, models[indexItem].Text);
                    indexItem++;
                }
            }
        }

        [Fact(DisplayName = "Test GetModels with high MakeId")]
        public void TestGetModelsHighMakeId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                IEnumerable<SelectListItem> models = carRepository.GetModelsSelectListItemsFromMakeId(100);
                Assert.Equal(Enumerable.Empty<SelectListItem>(), models);
            }
        }
    }

    [Collection("Makes")]
    public class TestCarRepositoryGetAllMakes : IClassFixture<MakesFixture>
    {
        private readonly MakesFixture _fixture;
        public TestCarRepositoryGetAllMakes(MakesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetModels with empty database")]
        public void TestGetModelEmptyDatabase()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                vehiclesContext.Database.EnsureDeleted();
                vehiclesContext.Database.EnsureCreated();
                CarRepository carRepository = new CarRepository(vehiclesContext);
                IEnumerable<SelectListItem> makes = carRepository.GetAllMakesSelectList();
                Assert.Equal(Enumerable.Empty<SelectListItem>(), makes);
            }
        }

        [Fact(DisplayName = "Test GetMakes with filled database")]
        public void TestGetMakesFilledDatabase()
        {
            SelectListItem nissanItem = new SelectListItem
            {
                Value = "1",
                Text = "Nissan"
            };
            SelectListItem jeepItem = new SelectListItem
            {
                Value = "2",
                Text = "Jeep"
            };
            List<SelectListItem> validMakesList = new List<SelectListItem>(){
                jeepItem,
                nissanItem
            };

            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                List<SelectListItem> makes = carRepository.GetAllMakesSelectList().ToList();
                Assert.Equal(2, makes.Count());
                int indexItem = 0;
                foreach (SelectListItem item in validMakesList)
                {
                    Assert.Equal(validMakesList[indexItem].Value, makes[indexItem].Value);
                    Assert.Equal(validMakesList[indexItem].Text, makes[indexItem].Text);
                    indexItem++;
                }
            }
        }


    }

    [Collection("Models")]
    public class TestCarRepositoryGetModelById: IClassFixture<ModelsFixture>
    {
        private readonly ModelsFixture _fixture;
        public TestCarRepositoryGetModelById(ModelsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetModelById with Id = 0")]
        public void TestGetModelIdZero()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Model model = carRepository.GetModelById(0);
                Assert.Null(model);
            }
        }

        [Fact(DisplayName = "Test GetModelById with Id < 0")]
        public void TestGetModelIdnegative()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Model model = carRepository.GetModelById(-1);
                Assert.Null(model);
            }
        }

        [Fact(DisplayName = "Test GetModelById with high Id")]
        public void TestGetModelHighId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Model model = carRepository.GetModelById(10);
                Assert.Null(model);
            }
        }

        [Fact(DisplayName = "Test GetModelById with valid Id")]
        public void TestGetModelValidId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Model model = carRepository.GetModelById(1);
                Model validModel = new Model { ModelId = 1, MakeId = 1, Name = "X-Trail" };
                Assert.Equal(validModel.ModelId, model.ModelId);
                Assert.Equal(validModel.MakeId, model.MakeId);
                Assert.Equal(validModel.Name, model.Name);
            }
        }

    }

    [Collection("Makes")]
    public class TestCarRepositoryGetMakeById : IClassFixture<MakesFixture>
    {
        private readonly MakesFixture _fixture;
        public TestCarRepositoryGetMakeById(MakesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetMakeById with Id = 0")]
        public void TestGetMakeIdZero()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Make make = carRepository.GetMakeById(0);
                Assert.Null(make);
            }
        }

        [Fact(DisplayName = "Test GetMakeById with Id < 0")]
        public void TestGetMakeIdnegative()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Make make = carRepository.GetMakeById(-1);
                Assert.Null(make);
            }
        }

        [Fact(DisplayName = "Test GetMakeById with high Id")]
        public void TestGetMakeHighId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Make make = carRepository.GetMakeById(10);
                Assert.Null(make);
            }
        }

        [Fact(DisplayName = "Test GetMakeById with valid Id")]
        public void TestGetMakeValidId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Make make = carRepository.GetMakeById(1);
                Make validMake = new Make { MakeId = 1, Name = "Nissan" };
                Assert.Equal(validMake.MakeId, make.MakeId);
                Assert.Equal(validMake.Name, make.Name);
            }
        }

    }

    [Collection("VehicleTypes")]
    public class TestCarRepositoryGetVehicleTypeById : IClassFixture<VehicleTypesFixture>
    {
        private readonly VehicleTypesFixture _fixture;
        public TestCarRepositoryGetVehicleTypeById(VehicleTypesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetVehicleTypeById with Id = 0")]
        public void TestGetVehicleTypeByIdZero()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeById(0);
                Assert.Null(vehicleType);
            }
        }

        [Fact(DisplayName = "Test GetVehicleTypeById with Id < 0")]
        public void TestGetVehicleTypeByIdNegative()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeById(-1);
                Assert.Null(vehicleType);
            }
        }

        [Fact(DisplayName = "Test GetVehicleTypeById with high Id")]
        public void TestGetVehicleTypeByIdHighId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeById(10);
                Assert.Null(vehicleType);
            }
        }

        [Fact(DisplayName = "Test GetVehicleTypeById with valid Id")]
        public void TestGetVehicleTypeByIdValidId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeById(1);
                VehicleType validVehicleType = new VehicleType { VehicleTypeId = 1, Name = "Car" };
                Assert.Equal(validVehicleType.VehicleTypeId, vehicleType.VehicleTypeId);
                Assert.Equal(validVehicleType.Name, vehicleType.Name);
            }
        }

    }

    [Collection("VehicleTypes")]
    public class TestCarRepositoryGetVehicleTypeByName : IClassFixture<VehicleTypesFixture>
    {
        private readonly VehicleTypesFixture _fixture;
        public TestCarRepositoryGetVehicleTypeByName(VehicleTypesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetVehicleTypeByName with an empty string")]
        public void TestGetVehicleTypeByNameEmptyString()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeByName("");
                Assert.Null(vehicleType);
            }
        }

        [Fact(DisplayName = "Test GetVehicleTypeByName with random string")]
        public void TestGetVehicleTypeByNameRandomString()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeByName("asdfaf");
                Assert.Null(vehicleType);
            }
        }

        [Fact(DisplayName = "Test GetVehicleTypeByName with special characters string")]
        public void TestGetVehicleTypeByNameSpecialString()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeByName("#%@****\"");
                Assert.Null(vehicleType);
            }
        }

        [Fact(DisplayName = "Test GetVehicleTypeByName with valid string")]
        public void TestGetVehicleTypeByNameValidString()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                VehicleType vehicleType = carRepository.GetVehicleTypeByName("Car");
                VehicleType validVehicleType = new VehicleType { VehicleTypeId = 1, Name = "Car" };
                Assert.Equal(validVehicleType.VehicleTypeId, vehicleType.VehicleTypeId);
                Assert.Equal(validVehicleType.Name, vehicleType.Name);
            }
        }

    }

    [Collection("BodyTypes")]
    public class TestCarRepositoryGetBodyTypeById : IClassFixture<BodyTypesFixture>
    {
        private readonly BodyTypesFixture _fixture;
        public TestCarRepositoryGetBodyTypeById(BodyTypesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetBodyTypeById with Id = 0")]
        public void TestGetBodyTypeByIdZero()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                BodyType bodyType = carRepository.GetBodyTypeById(0);
                Assert.Null(bodyType);
            }
        }

        [Fact(DisplayName = "Test GetBodyTypeById with Id < 0")]
        public void TestGetBodyTypeByIdNegative()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                BodyType bodyType = carRepository.GetBodyTypeById(-1);
                Assert.Null(bodyType);
            }
        }

        [Fact(DisplayName = "Test GetBodyTypeById with high Id")]
        public void TestGetBodyTypeByIdHighId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                BodyType bodyType = carRepository.GetBodyTypeById(10);
                Assert.Null(bodyType);
            }
        }

        [Fact(DisplayName = "Test GetBodyTypeById with valid Id")]
        public void TestGetBodyTypeByIdValidId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                BodyType bodyType = carRepository.GetBodyTypeById(1);
                BodyType validBodyType = new BodyType { BodyTypeId = 1, Name = "Wagon" };
                Assert.Equal(validBodyType.BodyTypeId, bodyType.BodyTypeId);
                Assert.Equal(validBodyType.Name, bodyType.Name);
            }
        }

    }

    [Collection("BodyTypes")]
    public class TestCarRepositoryGetAllBodyTypes : IClassFixture<BodyTypesFixture>
    {
        private readonly BodyTypesFixture _fixture;
        public TestCarRepositoryGetAllBodyTypes(BodyTypesFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetAllBodyTypes with empty database")]
        public void TestGetAllBodyTypesEmptyDatabase()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                vehiclesContext.Database.EnsureDeleted();
                vehiclesContext.Database.EnsureCreated();
                CarRepository carRepository = new CarRepository(vehiclesContext);
                IEnumerable<SelectListItem> bodyTypes = carRepository.GetAllBodyTypesSelectList();
                Assert.Equal(Enumerable.Empty<SelectListItem>(), bodyTypes);
            }
        }

        [Fact(DisplayName = "Test GetAllBodyTypes with filled database")]
        public void TestGetAllBodyTypesFilledDatabase()
        {
            SelectListItem wagonItem = new SelectListItem
            {
                Value = "1",
                Text = "Wagon"
            };
            SelectListItem suvItem = new SelectListItem
            {
                Value = "2",
                Text = "SUV"
            };
            List<SelectListItem> validBodyTypesList = new List<SelectListItem>(){
                suvItem,
                wagonItem
            };

            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                List<SelectListItem> bodyTypes = carRepository.GetAllBodyTypesSelectList().ToList();
                Assert.Equal(2, bodyTypes.Count());
                int indexItem = 0;
                foreach (SelectListItem item in validBodyTypesList)
                {
                    Assert.Equal(validBodyTypesList[indexItem].Value, bodyTypes[indexItem].Value);
                    Assert.Equal(validBodyTypesList[indexItem].Text, bodyTypes[indexItem].Text);
                    indexItem++;
                }
            }
        }
    }

    [Collection("Cars")]
    public class TestCarRepositoryGetCarById : IClassFixture<CarsFixture>
    {
        private readonly CarsFixture _fixture;
        public TestCarRepositoryGetCarById(CarsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test GetCarById with Id = 0")]
        public void TestGetCarByIdZero()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Car car = carRepository.GetCarById(0);
                Assert.Null(car);
            }
        }

        [Fact(DisplayName = "Test GetCarById with Id < 0")]
        public void TestGetCarByIdNegative()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Car car = carRepository.GetCarById(-1);
                Assert.Null(car);
            }
        }

        [Fact(DisplayName = "Test GetCarById with high Id")]
        public void TestGetCarByIdHighId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Car car = carRepository.GetCarById(100);
                Assert.Null(car);
            }
        }

        [Fact(DisplayName = "Test GetCarById with valid Id")]
        public void TestGetCarByIdValidId()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                CarRepository carRepository = new CarRepository(vehiclesContext);
                Car car = carRepository.GetCarById(1);
                Car validCar = new Car
                {
                    CarId = 1,
                    MakeId = 1,
                    Engine = "v6",
                    Doors = 4,
                    Wheels = 4,
                    BodyTypeId = 1,
                    ModelId = 1,
                    AddDate = DateTime.Today,
                    IsSold = false,
                    VehicleTypeId = 1
                };
                Assert.Equal(validCar.CarId, car.CarId);
                Assert.Equal(validCar.MakeId, car.MakeId);
                Assert.Equal(validCar.Engine, car.Engine);
                Assert.Equal(validCar.Doors, car.Doors);
                Assert.Equal(validCar.Wheels, car.Wheels);
                Assert.Equal(validCar.BodyTypeId, car.BodyTypeId);
                Assert.Equal(validCar.ModelId, car.ModelId);
                Assert.Equal(validCar.AddDate, car.AddDate);
                Assert.Equal(validCar.IsSold, car.IsSold);
                Assert.Equal(validCar.VehicleTypeId, car.VehicleTypeId);
            }
        }

    }

    [Collection("Cars")]
    public class TestCarRepositoryInsertCar : IClassFixture<CarsFixture>
    {
        private readonly CarsFixture _fixture;
        public TestCarRepositoryInsertCar(CarsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Test Insert Valid Car")]
        public void TestInsertValidCar()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                Car carToInsert = new Car
                {
                    CarId = 13,
                    MakeId = 1,
                    Engine = "v6",
                    Doors = 4,
                    Wheels = 4,
                    BodyTypeId = 1,
                    ModelId = 1,
                    AddDate = DateTime.Today,
                    IsSold = false,
                    VehicleTypeId = 1
                };

                CarRepository carRepository = new CarRepository(vehiclesContext);
                int carId = carRepository.InsertCar(carToInsert);

                Assert.Equal(13, carId);
                Car latest_car = new VehiclesContext(_fixture.options).Cars.OrderByDescending(c => c.CarId).First();

                Assert.Equal(carToInsert.CarId, latest_car.CarId);
                Assert.Equal(carToInsert.MakeId, latest_car.MakeId);
                Assert.Equal(carToInsert.Engine, latest_car.Engine);
                Assert.Equal(carToInsert.Doors, latest_car.Doors);
                Assert.Equal(carToInsert.Wheels, latest_car.Wheels);
                Assert.Equal(carToInsert.BodyTypeId, latest_car.BodyTypeId);
                Assert.Equal(carToInsert.ModelId, latest_car.ModelId);
                Assert.Equal(carToInsert.AddDate, latest_car.AddDate);
                Assert.Equal(carToInsert.IsSold, latest_car.IsSold);
                Assert.Equal(carToInsert.VehicleTypeId, latest_car.VehicleTypeId);

            }
        }

        [Fact(DisplayName = "Test Insert Existing Car")]
        public void TestInsertExistingCar()
        {
            using (var vehiclesContext = new VehiclesContext(_fixture.options))
            {
                Car carToInsert = new Car
                {
                    CarId = 2,
                    MakeId = 1,
                    Engine = "v4",
                    Doors = 4,
                    Wheels = 4,
                    BodyTypeId = 2,
                    ModelId = 3,
                    AddDate = DateTime.Today,
                    IsSold = false,
                    VehicleTypeId = 1
                };

                CarRepository carRepository = new CarRepository(vehiclesContext);
                int carId = carRepository.InsertCar(carToInsert);

                Assert.Equal(0, carId);
                Car latest_car = new VehiclesContext(_fixture.options).Cars.OrderByDescending(c => c.CarId).First();

                Assert.NotEqual(carToInsert.CarId, latest_car.CarId);
            }
        }
    }
}
