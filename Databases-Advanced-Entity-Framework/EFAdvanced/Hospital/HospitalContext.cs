using Hospital.Models;

namespace Hospital
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HospitalContext : DbContext
    {
        // Your context has been configured to use a 'HospitalContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Hospital.HospitalContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HospitalContext' 
        // connection string in the application configuration file.
        public HospitalContext()
            : base("name=HospitalContext")
        {
        }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<Medicament> Medicaments { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }

        public  virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }
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