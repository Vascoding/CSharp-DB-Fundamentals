

namespace CarDealer
{
    using System.Xml.Linq;
    using System;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Models;

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

            //Query 1 – Cars
            //Cars(context);

            // Query 2 – Cars from make Ferrari
            //CarsFromMakeFerrari(context);

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
            XElement xmlDoc = new XElement("sales");
            foreach (var s in sales)
            {
                XElement saleElement = new XElement("sale");
                XElement carElement = new XElement("car");
                carElement.SetAttributeValue("make", s.car.Make);
                carElement.SetAttributeValue("model", s.car.Model);
                carElement.SetAttributeValue("travelled-distance", s.car.TravelledDistance);

                XElement customerElement = new XElement("customer-name");
                customerElement.Value = s.customerName;

                XElement discountElement = new XElement("discount");
                discountElement.Value = s.Discount.ToString();

                XElement priceElement = new XElement("price");
                priceElement.Value = s.price.ToString();

                XElement priceWithDiscountElement = new XElement("price-with-discount");
                priceWithDiscountElement.Value = s.priceWithDiscount.ToString();

                saleElement.Add(carElement, customerElement, discountElement, priceElement, priceWithDiscountElement);
                xmlDoc.Add(saleElement);
            }
            Console.WriteLine(xmlDoc);
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

            XElement xmlDoc = new XElement("customers");
            foreach (var c in customers)
            {
                XElement customerElement = new XElement("customer");
                customerElement.SetAttributeValue("full-name", c.fullName);
                customerElement.SetAttributeValue("bought-cars", c.boughtCars);
                customerElement.SetAttributeValue("spent-money", c.spentMoney);
                xmlDoc.Add(customerElement);
            }
            Console.WriteLine(xmlDoc);
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
            XElement xmlDoc = new XElement("cars");
            foreach (var c in cars)
            {
                XElement carElement = new XElement("car");
                carElement.SetAttributeValue("make", c.car.Make);
                carElement.SetAttributeValue("model", c.car.Model);
                carElement.SetAttributeValue("travelled-distance", c.car.TravelledDistance);
                XElement partElement = new XElement("parts");
                foreach (var p in c.pars)
                {
                    XElement eachPart = new XElement("part");
                    eachPart.SetAttributeValue("name", p.Name);
                    eachPart.SetAttributeValue("price", p.Price);
                    partElement.Add(eachPart);
                }
                carElement.Add(partElement);
                xmlDoc.Add(carElement);
            }
            Console.WriteLine(xmlDoc);
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
            XElement xmlDoc = new XElement("suppliers");
            foreach (var s in suppliers)
            {
                XElement suppElement = new XElement("supplier");
                suppElement.SetAttributeValue("id", s.Id);
                suppElement.SetAttributeValue("name", s.Name);
                suppElement.SetAttributeValue("parts-count", s.PartsCount);
                xmlDoc.Add(suppElement);
            }
            Console.WriteLine(xmlDoc);
        }

        private static void CarsFromMakeFerrari(CarDealerContext context)
        {
            var cars =
                            context.Cars.Where(c => c.Make == "Ferrari")
                                .OrderBy(c => c.Model)
                                .ThenByDescending(c => c.TravelledDistance)
                                .Select(c => new
                                {
                                    Id = c.Id,
                                    Model = c.Model,
                                    TravelledDistance = c.TravelledDistance
                                })
                                .ToList();

            XElement xmlDoc = new XElement("cars");
            foreach (var c in cars)
            {
                XElement carElement = new XElement("car");
                carElement.SetAttributeValue("id", c.Id);
                carElement.SetAttributeValue("model", c.Model);
                carElement.SetAttributeValue("travellend-distance", c.TravelledDistance);
                xmlDoc.Add(carElement);
            }
            Console.WriteLine(xmlDoc);
        }

        private static void Cars(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Model)
                .ToList();
            XElement xmlDoc = new XElement("cars");
            foreach (var c in cars)
            {
                XElement carElement = new XElement("car");
                carElement.SetElementValue("make", c.Make);
                carElement.SetElementValue("model", c.Model);
                carElement.SetElementValue("travelled-distance", c.TravelledDistance);
                xmlDoc.Add(carElement);
            }
            Console.WriteLine(xmlDoc);
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
            XDocument xmlDoc = XDocument.Load("../../Import/customers.xml");
            XElement customersElement = xmlDoc.Root;
            
            foreach (var c in customersElement.Elements())
            {
                string name = c.Attribute("name")?.Value;
                DateTime birthDate = DateTime.Parse(c.Element("birth-date").Value);
                bool isYoungDriver = bool.Parse(c.Element("is-young-driver").Value);
                Customer customer = new Customer();
                customer.Name = name;
                customer.BirthDate = birthDate;
                customer.IsYoungDriver = isYoungDriver;
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        private static void ImportCars(CarDealerContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/cars.xml");
            XElement carsElement = xmlDoc.Root;
            Random rnd = new Random();
            var partCount = context.Parts.Count();
            foreach (var c in carsElement.Elements())
            {
                string make = c.Element("make")?.Value;
                string model = c.Element("model")?.Value;
                long travelled = long.Parse(c.Element("travelled-distance").Value);
                Car car = new Car();
                car.Make = make;
                car.Model = model;
                car.TravelledDistance = travelled;
                for (int i = 0; i < 15; i++)
                {
                    int partId = rnd.Next(1, partCount);
                    var part = context.Parts.Find(partId);
                    car.Parts.Add(part);
                }
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        private static void ImportParts(CarDealerContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/parts.xml");
            XElement partsElement = xmlDoc.Root;
            Random rnd = new Random();
            foreach (var p in partsElement.Elements())
            {
                string name = p.Attribute("name")?.Value;
                decimal price = decimal.Parse(p.Attribute("price").Value);
                int quantity = int.Parse(p.Attribute("quantity").Value);
                int suppCount = context.Suppliers.Count();
                int suppId = rnd.Next(1, suppCount);
                Part part = new Part();
                part.Name = name;
                part.Price = price;
                part.Quantity = quantity;
                part.Supplier = context.Suppliers.Find(suppId);
                context.Parts.Add(part);
                context.SaveChanges();
            }
        }

        private static void ImportSuppliers(CarDealerContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/suppliers.xml");
            XElement suppliersElement = xmlDoc.Root;
            foreach (var s in suppliersElement.Elements())
            {
                string name = s.Attribute("name")?.Value;
                bool isImporter = bool.Parse(s.Attribute("is-importer").Value);
                Supplier supp = new Supplier();
                supp.Name = name;
                supp.IsImporter = isImporter;
                context.Suppliers.Add(supp);
                context.SaveChanges();
            }
        }
    }
}
