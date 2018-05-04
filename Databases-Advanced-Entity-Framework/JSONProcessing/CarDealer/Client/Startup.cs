

namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Models;
    using Newtonsoft.Json;
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //5. Car Dealer Import Data

            //ImportSuppliers(context);
            //ImportParts(context);
            //ImportCars(context);
            //ImportCustomers(context);
            //ImportSales(context);

            //6. Car Dealer Query and Export Data

            //Query 1 – Ordered Customers
            //OrderedCustomers(context);

            //Query 2 – Cars from make Toyota
            //CarsFromMakeToyota(context);

            //Query 3 – Local Suppliers
            //LocalSuppliers(context);

            //Query 4 – Cars with Their List of Parts
            //CarsWithTheirParts(context);

            //Query 5 – Total Sales by Customer
            //TotalSalesByCustomer(context);

            //Query 6 – Sales with Applied Discount
            //SalesWithDiscount(context);
        }

        private static void SalesWithDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TravelledDistance = s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount,
                price = s.Car.Parts.Sum(p => p.Price),
                priceWithDiscount = s.Car.Parts.Sum(p => p.Price) - s.Car.Parts.Sum(p => p.Price) * s.Discount
            }).ToList();
            string json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customers =
                            context.Customers.Where(c => c.Sales.Count > 0)
                                .OrderByDescending(c => c.Sales.Sum(v => v.Car.Parts.Sum(b => b.Price)))
                                .ThenByDescending(c => c.Sales.Count)
                                .Select(c => new
                                {
                                    fullName = c.Name,
                                    boughtCars = c.Sales.Count,
                                    spentMoney = c.Sales.Sum(v => v.Car.Parts.Sum(b => b.Price))
                                }).ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CarsWithTheirParts(CarDealerContext context)
        {
            var cars = context.Cars
                            .Select(c => new
                            {
                                car = new
                                {
                                    Make = c.Make,
                                    Model = c.Model,
                                    TravelledDistance = c.TravelledDistance
                                },
                                pars = c.Parts.Select(p => new
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                            });
            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                            .Where(s => s.IsImporter == false)
                            .Select(s => new
                            {
                                Id = s.Id,
                                Name = s.Name,
                                PartsCount = s.Parts.Count
                            }).ToList();
            string json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CarsFromMakeToyota(CarDealerContext context)
        {
            var cars =
                            context.Cars.Where(c => c.Make == "Toyota")
                                .OrderBy(c => c.Model)
                                .ThenByDescending(c => c.TravelledDistance)
                                .Select(c => new
                                {
                                    Id = c.Id,
                                    Make = c.Make,
                                    Model = c.Model,
                                    TravelledDistance = c.TravelledDistance
                                })
                                .ToList();

            string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                            .OrderBy(c => c.BirthDate)
                            .ThenBy(c => c.IsYoungDriver)
                            .Select(c => new
                            {
                                Id = c.Id,
                                Name = c.Name,
                                BirthDate = c.BirthDate,
                                IsYoungDriver = c.IsYoungDriver,
                                Sales = c.Sales
                            }).ToList();

            string json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ImportSales(CarDealerContext context)
        {
            Random rnd = new Random();
            int carCount = context.Cars.Count();
            int customerCount = context.Customers.Count();
            decimal[] discounts = new[] { 0.0m, 0.05m, 0.1m, 0.15m, 0.2m, 0.3m, 0.4m, 0.5m };
            for (int i = 0; i < 50; i++)
            {
                int carId = rnd.Next(1, carCount);
                int customerId = rnd.Next(1, customerCount);
                int disc = rnd.Next(0, 7);
                Sale sale = new Sale();
                sale.Car = context.Cars.Find(carId);
                sale.Customer = context.Customers.Find(customerId);
                if (sale.Customer.IsYoungDriver)
                {
                    sale.Discount = discounts[disc] + 0.05m;

                }
                else
                {
                    sale.Discount = discounts[disc];
                }
                context.Sales.Add(sale);
            }
            context.SaveChanges();
        }

        private static void ImportCustomers(CarDealerContext context)
        {
            string json = File.ReadAllText("../../Import/customers.json");

            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void ImportCars(CarDealerContext context)
        {
            string json = File.ReadAllText("../../Import/cars.json");
            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(json);
            Random rnd = new Random();
            int partCount = context.Parts.Count();
            foreach (var car in cars)
            {
                for (int i = 0; i < 15; i++)
                {
                    int id = rnd.Next(1, partCount);
                    var part = context.Parts.Find(id);
                    car.Parts.Add(part);
                }
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void ImportParts(CarDealerContext context)
        {
            string json = File.ReadAllText("../../Import/parts.json");
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(json);
            Random rnd = new Random();
            int suppCount = context.Suppliers.Count();
            foreach (var p in parts)
            {
                int id = rnd.Next(1, suppCount);

                p.Supplier = context.Suppliers.Find(id);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            string json = File.ReadAllText("../../Import/suppliers.json");
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(json);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }
    }
}
