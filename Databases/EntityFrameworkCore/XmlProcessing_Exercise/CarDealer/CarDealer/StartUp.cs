using CarDealer.Data;
using CarDealer.DTO.Import;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using CarDealer.Models;
using System;
using System.Linq;
using AutoMapper;
using CarDealer.DTO.Export;
using System.Text;

namespace CarDealer
{
    public class StartUp
    {
        private const string DatasetsDirPath = "../../../Datasets";
        private const string ExportDirPath = "../../../Datasets/Export";
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //ResetDatabase(context);

            //string suppliersInputXml = File.ReadAllText(DatasetsDirPath + "/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersInputXml));

            //string partsInputXml = File.ReadAllText(DatasetsDirPath + "/parts.xml");
            //Console.WriteLine(ImportParts(context, partsInputXml));

            //string carsInputXml = File.ReadAllText(DatasetsDirPath + "/cars.xml");
            //Console.WriteLine(ImportCars(context, carsInputXml));

            //string customersInputXml = File.ReadAllText(DatasetsDirPath + "/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersInputXml));

            //string salesInputXml = File.ReadAllText(DatasetsDirPath + "/sales.xml");
            //Console.WriteLine(ImportSales(context, salesInputXml));

            EnsureExportDirectoryExists();

            //string carsExport = GetCarsWithDistance(context);
            //File.WriteAllText(ExportDirPath + "/cars.xml", carsExport);

            //string carsBmwExport = GetCarsFromMakeBmw(context);
            //File.WriteAllText(ExportDirPath + "/bmw-cars.xml", carsBmwExport);

            //string localSuppliersExport = GetLocalSuppliers(context);
            //File.WriteAllText(ExportDirPath + "/local-suppliers.xml", localSuppliersExport);

            //string carsWithPartsExport = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText(ExportDirPath + "/cars-and-parts.xml", carsWithPartsExport);

            //string totalSalesByCustomer = GetTotalSalesByCustomer(context);
            //File.WriteAllText(ExportDirPath + "/customers-total-sales.xml", totalSalesByCustomer);

            string salesExport = GetSalesWithAppliedDiscount(context);
            File.WriteAllText(ExportDirPath + "/sales-discounts.xml", salesExport);
        }


        //Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = 
                new XmlSerializer(typeof(SupplierImportDto[]), new XmlRootAttribute("Suppliers"));

            SupplierImportDto[] supplierDtos;
            using (var reader = new StringReader(inputXml))
            {
               supplierDtos = (SupplierImportDto[])serializer.Deserialize(reader);
            }

            List<Supplier> suppliers = supplierDtos
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        //Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(PartImportDto[]), new XmlRootAttribute("Parts"));

            PartImportDto[] partDtos;
            using (var reader = new StringReader(inputXml))
            {
                partDtos = (PartImportDto[])serializer.Deserialize(reader);
            }

            var suppliersIds = context.Suppliers.Select(s => s.Id).ToArray();

            List<Part> parts = partDtos
                .Where(x => suppliersIds.Contains(x.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToList();


            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml) 
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(CarImportDto[]), new XmlRootAttribute("Cars"));

            CarImportDto[] carDtos;

            using (var reader = new StringReader(inputXml))
            {
                carDtos = (CarImportDto[])serializer.Deserialize(reader);
            }

            List<Car> cars = new List<Car>();

            foreach (var dto in carDtos)
            {
                var distinctParts = dto.Parts
                    .Select(x => x.Id)
                    .Distinct()
                    .Where(x => context.Parts.Select(p => p.Id).Contains(x));

                Car car = new Car
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TravelledDistance = dto.TraveledDistance
                };

                foreach (var partId in distinctParts)
                {

                    PartCar partCar = new PartCar
                    {
                        PartId = partId
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
               new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));

            CustomerImportDto[] customerDtos;
            using (var reader = new StringReader(inputXml))
            {
                customerDtos = (CustomerImportDto[])serializer.Deserialize(reader);
            }

            List<Customer> customers = customerDtos
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        //Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer =
                new XmlSerializer(typeof(SaleImportDto[]), new XmlRootAttribute("Sales"));

            SaleImportDto[] saleDtos;
            using (var reader = new StringReader(inputXml))
            {
                saleDtos = (SaleImportDto[])serializer.Deserialize(reader);
            }

            List<Sale> sales = saleDtos
                .Where(x => context.Cars.Select(x => x.Id).Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarExportDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Take(10)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(CarExportDto[]), new XmlRootAttribute("cars"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarBmwExportDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(CarBmwExportDto[]), new XmlRootAttribute("cars"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSupplierExportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();


            XmlSerializer serializer =
                new XmlSerializer(typeof(LocalSupplierExportDto[]), new XmlRootAttribute("suppliers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, suppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var cars = context.Cars
                .Select(c => new CarWithAllPartsExportDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new PartExportDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();


            XmlSerializer serializer =
                new XmlSerializer(typeof(CarWithAllPartsExportDto[]), new XmlRootAttribute("cars"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, cars, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new CustomerWithSalesExportDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Select(s => s.Car)
                    .SelectMany(c => c.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();


            XmlSerializer serializer =
                new XmlSerializer(typeof(CustomerWithSalesExportDto[]), new XmlRootAttribute("customers"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, customers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        //Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var sales = context.Sales
                .Select(s => new SaleExportDto
                {
                    Car = new CarSaleExportDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Select(pc => pc.Part.Price).Sum(),
                    PriceWithDiscount = s.Car.PartCars.Select(pc => pc.Part.Price).Sum() -
                                s.Car.PartCars.Select(pc => pc.Part.Price).Sum() * s.Discount / 100
                })
                .ToArray();

            XmlSerializer serializer =
                new XmlSerializer(typeof(SaleExportDto[]), new XmlRootAttribute("sales"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, sales, namespaces);
            }

            return sb.ToString().Trim();
        }


        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static void EnsureExportDirectoryExists()
        {
            if (!Directory.Exists(ExportDirPath))
            {
                Directory.CreateDirectory(ExportDirPath);
            }
        }
        
    }
}