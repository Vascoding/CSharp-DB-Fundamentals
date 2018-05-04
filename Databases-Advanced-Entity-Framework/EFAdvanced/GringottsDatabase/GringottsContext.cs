using GringottsDatabase.Models;

namespace GringottsDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class GringottsContext : DbContext
    {
        // Your context has been configured to use a 'GringottsContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GringottsDatabase.GringottsContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GringottsContext' 
        // connection string in the application configuration file.
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }

        public virtual DbSet<WizardDeposits> WizardDeposits { get; set; }

        public virtual DbSet<User> User { get; set; }

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