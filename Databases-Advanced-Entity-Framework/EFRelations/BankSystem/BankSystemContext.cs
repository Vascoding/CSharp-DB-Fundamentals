using BankSystem.Models;

namespace BankSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankSystemContext : DbContext
    {
        // Your context has been configured to use a 'BankSystemContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BankSystem.BankSystemContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BankSystemContext' 
        // connection string in the application configuration file.
        public BankSystemContext()
            : base("name=BankSystemContext")
        {
        }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public DbSet<SavingAccount> SavingAccounts { get; set; }


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