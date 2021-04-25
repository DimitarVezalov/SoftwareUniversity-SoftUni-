using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private const string exportDirectoryPath = "../../../Datasets/Export";

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //string importSuppliersString = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, importSuppliersString));

            //string importPartsString = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, importPartsString));

            //string importCarsString = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, importCarsString));

            //string importCustomersString = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, importCustomersString));

            //string importSalesString = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, importSalesString));

            CreateExportDirectory();

            //string exportOrderedCustomers = GetOrderedCustomers(context);
            //File.WriteAllText(exportDirectoryPath + "/ordered-customers.json", exportOrderedCustomers);

            //string exportToyotaCars = GetCarsFromMakeToyota(context);
            //File.WriteAllText(exportDirectoryPath + "/toyota-cars.json", exportToyotaCars);

            //string exportLocalSuppliers = GetLocalSuppliers(context);
            //File.WriteAllText(exportDirectoryPath + "/local-suppliers.json", exportLocalSuppliers);

            //string carsAndParts = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText(exportDirectoryPath + "/cars-and-parts.json", carsAndParts);

            //string exportCustomersWithSales = GetTotalSalesByCustomer(context);
            //File.WriteAllText(exportDirectoryPath + "/customers-total-sales.json", exportCustomersWithSales);

            //string exportSalesDiscounts = GetSalesWithAppliedDiscount(context);
            //File.WriteAllText(exportDirectoryPath + "/sales-discounts.json", exportSalesDiscounts);

        }


        //Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            foreach (var part in parts)
            {
                if (context.Suppliers.Select(s => s.Id).Contains(part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {parts.Count - (parts.Count - context.Parts.Count())}.";
        }

        //Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarInputModelDto>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    currentCar.PartCars.Add(new PartCar { PartId = partId });
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        //Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new 
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    parts = c.PartCars.Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                    .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Select(s => s.Car.PartCars.Select(pc => pc.Part.Price).Sum()).Sum()
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Select(pc => pc.Part.Price).Sum().ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Select(pc => pc.Part.Price).Sum() - 
                                (s.Car.PartCars.Select(pc => pc.Part.Price).Sum() * (s.Discount / 100))).ToString("F2")
                })
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        private static void CreateExportDirectory()
        {
            if (!Directory.Exists(exportDirectoryPath))
            {
                Directory.CreateDirectory(exportDirectoryPath);
            }
        }
    }
}