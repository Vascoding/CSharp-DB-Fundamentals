using Sales.Models;

namespace Sales.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() {Name = "Vodka"});
            context.Products.AddOrUpdate(new Product() {Name = "Bread"});
            context.Products.AddOrUpdate(new Product() {Name = "Beer"});

            context.Customers.AddOrUpdate(new Customer() { FirstName = "Ivancho", LastName = "Petrov"});
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Dancho", LastName = "Kirov"});
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Pesho", LastName = "Dimitrov"});
        }
    }
}
