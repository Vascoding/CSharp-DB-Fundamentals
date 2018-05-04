using System.Data.Entity.Migrations;
using Sales.Migrations;
using Sales.Models;

namespace Sales
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesContext : DbContext
    {
        // Your context has been configured to use a 'SalesContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Sales.SalesContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SalesContext' 
        // connection string in the application configuration file.
        public SalesContext()
            : base("name=SalesContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }    
        
        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<StoreLocation> StoreLocations { get; set; }

        

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}