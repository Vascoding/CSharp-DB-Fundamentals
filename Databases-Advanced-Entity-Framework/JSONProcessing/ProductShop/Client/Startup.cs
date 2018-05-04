
namespace ProductShop.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Models;

    class Startup
    {
        static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //2. Import data
            ImportUsers(context);
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

            string json = JsonConvert.SerializeObject(new { usersCount = users.Count(), users }, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CategoriesByProductCount(ProductShopContext context)
        {
            var categories = context.Categories
                            .OrderBy(c => c.Name)
                            .Select(c => new
                            {
                                category = c.Name,
                                productCount = c.Products.Count,
                                averagePrice = c.Products.Average(p => p.Price).ToString(),
                                totalRevenue = c.Products.Sum(p => p.Price).ToString()
                            });

            string json = JsonConvert.SerializeObject(categories, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void SoldProducts(ProductShopContext context)
        {
            var users = context.Users
                            .Where(u => u.ProductsSold.Count > 0)
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Select(u => new
                            {
                                fisrtName = u.FirstName,
                                lastName = u.LastName,
                                soldProducts = u.ProductsSold.Select(p => new
                                {
                                    name = p.Name,
                                    prie = p.Price,
                                    buyerFirstName = p.Buyer.FirstName,
                                    buyerLastName = p.Buyer.LastName
                                })
                            });
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                            .Where(p => p.Price >= 500 && p.Price <= 1000)
                            .OrderBy(p => p.Price)
                            .Select(p => new
                            {
                                productName = p.Name,
                                productPrice = p.Price,
                                sellerName = p.Seller.FirstName + " " + p.Seller.LastName
                            });
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void ImportCategories(ProductShopContext context)
        {
            string jsonCategories = File.ReadAllText("../../Import/categories.json");

            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(jsonCategories);
            Random rnd = new Random();
            context.SaveChanges();
            var products = context.Products;
            foreach (var p in products)
            {
                int Id = rnd.Next(1, context.Categories.Count());
                var category = context.Categories.Find(Id);
                p.Categories.Add(category);
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProducts(ProductShopContext context)
        {
            string jsonProducts = File.ReadAllText("../../Import/products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);
            Random rnd = new Random();
            foreach (var p in products)
            {
                int Id = rnd.Next(1, context.Users.Count());
                if (Id % 3 == 0)
                {
                    p.BuyerId = Id;
                }
                p.SellerId = Id;
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            string json = File.ReadAllText("../../Import/users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
