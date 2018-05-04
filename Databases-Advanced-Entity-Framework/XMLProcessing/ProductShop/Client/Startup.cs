
namespace ProductShop.Client
{
    using System.Xml.Linq;
    using System;
    using System.Linq;
    using ProductShop.Data;
    using ProductShop.Models;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //2. Import data
            //ImportUsers(context);
            //ImportProducts(context);
            //ImportCategories(context);


            //3. Query and export data
            //Query 1 - Products in range 
            //ProductsInRange(context);


            //Query 2 - Successfull sold products
            //SoldProducts(context);


            //Query 3 - Categories By Products Count
            //CategoriesByProductCount(context);

            //Query 4 - Users and Products
            //UsersAndProducts(context);

        }

        private static void UsersAndProducts(ProductShopContext context)
        {
            var users = context.Users
                            .Where(u => u.ProductsSold.Count > 0)
                            .OrderByDescending(u => u.ProductsSold.Count)
                            .ThenBy(u => u.LastName)
                            .Select(u => new
                            {
                                fistName = u.FirstName,
                                lastName = u.LastName,
                                age = u.Age,
                                soldProducts = new
                                {
                                    count = u.ProductsSold.Count,
                                    products = u.ProductsSold.Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    })
                                }
                            });

            XElement xmlDoc = new XElement("users", new XAttribute("count", users.Count()));

            foreach (var u in users)
            {
                XElement usersElement = new XElement("user");
                usersElement.SetAttributeValue("first-name", u.fistName);
                usersElement.SetAttributeValue("last-name", u.lastName);
                usersElement.SetAttributeValue("age", u.age);
                XElement soldProducts = new XElement("sold-products");
                soldProducts.SetAttributeValue("count", u.soldProducts.count);
                foreach (var s in u.soldProducts.products)
                {
                    XElement productElement = new XElement("product");
                    productElement.SetAttributeValue("name", s.name);
                    productElement.SetAttributeValue("price", s.price);
                    soldProducts.Add(productElement);
                }
                usersElement.Add(soldProducts);
                xmlDoc.Add(usersElement);
            }
            xmlDoc.Save("../../user.xml");
        }

        private static void CategoriesByProductCount(ProductShopContext context)
        {
            var categories = context.Categories
                            .OrderBy(c => c.Products.Count)
                            .Select(c => new
                            {
                                categoryName = c.Name,
                                productCount = c.Products.Count,
                                averagePrice = c.Products.Average(p => p.Price).ToString(),
                                totalRevenue = c.Products.Sum(p => p.Price).ToString()
                            });

            XElement xmlDoc = new XElement("categories");
            foreach (var c in categories)
            {
                xmlDoc.Add(new XElement("category", 
                    new XAttribute("name", c.categoryName), 
                    new XElement("product-count", c.productCount), 
                    new XElement("average-price", c.averagePrice), 
                    new XElement("total-revenue", c.totalRevenue)));
            }
            
            Console.WriteLine(xmlDoc);
        }

        private static void SoldProducts(ProductShopContext context)
        {
            var users = context.Users
                            .Where(u => u.ProductsSold.Count > 0)
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Select(u => new
                            {
                                firstName = u.FirstName,
                                lastName = u.LastName,
                                soldProducts = u.ProductsSold.Select(s => new
                                {
                                    name = s.Name,
                                    price = s.Price
                                })
                            }).ToList();
            XElement xmlDoc = new XElement("users");
            foreach (var u in users)
            {
                XElement userElement = new XElement("user");
                userElement.SetAttributeValue("first-name", u.firstName);
                userElement.SetAttributeValue("last-name", u.lastName);
                XElement soldProducts = new XElement("sold-products");
                foreach (var s in u.soldProducts)
                {
                    XElement productElement = new XElement("product");
                    productElement.SetElementValue("name", s.name);
                    productElement.SetElementValue("price", s.price);
                    
                    soldProducts.Add(productElement);
                }
                userElement.Add(soldProducts);
                xmlDoc.Add(userElement);
            }
            Console.WriteLine(xmlDoc);
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                            .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer.ProductsBought.Count > 0)
                            .OrderBy(p => p.Price)
                            .Select(p => new
                            {
                                productName = p.Name,
                                productPrice = p.Price,
                                buyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
                            }).ToList();
            XDocument xmlDoc = new XDocument(new XElement("products"));
            foreach (var p in products)
            {
                xmlDoc.Root.Add(new XElement("product", 
                    new XAttribute("name", p.productName), 
                    new XAttribute("price", p.productPrice), 
                    new XAttribute("buyer", p.buyerName.Trim())));
            }
            Console.WriteLine(xmlDoc);
            //xmlDoc.Save("../../products.xml");
        }

        private static void ImportCategories(ProductShopContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/categories.xml");
            XElement categories = xmlDoc.Root;
            foreach (var c in categories.Elements())
            {
                string name = c.Element("name").Value;
                Category category = new Category();
                category.Name = name;
                context.Categories.Add(category);
            }
            context.SaveChanges();

            Random rnd = new Random();
            var products = context.Products;
            foreach (var p in products)
            {
                int Id = rnd.Next(1, context.Categories.Count());
                var category = context.Categories.Find(Id);
                p.Categories.Add(category);
            }
            context.SaveChanges();
        }

        private static void ImportProducts(ProductShopContext context)
        {

            XDocument xmlDoc = XDocument.Load("../../Import/products.xml");
            XElement products = xmlDoc.Root;
            Random rnd = new Random();
            int usersCount = context.Users.Count();
            foreach (var p in products.Elements())
            {
                string name = p.Element("name").Value;
                decimal price = decimal.Parse(p.Element("price").Value);
                Product product = new Product();
                product.Name = name;
                product.Price = price;
                int Id = rnd.Next(1, usersCount);
                if (Id % 3 == 0)
                {
                    product.BuyerId = Id;
                    Id = rnd.Next(1, usersCount);
                }
                product.SellerId = Id;
                context.Products.Add(product);
            }
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            XDocument xmlDoc = XDocument.Load("../../Import/users.xml");
            XElement users = xmlDoc.Root;
            foreach (var u in users.Elements())
            {
                int i;
                string firstName = u.Attribute("first-name")?.Value;
                string lastName = u.Attribute("last-name")?.Value;
                int.TryParse(u.Attribute("age")?.Value, out i);
                User user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = i
                };
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
