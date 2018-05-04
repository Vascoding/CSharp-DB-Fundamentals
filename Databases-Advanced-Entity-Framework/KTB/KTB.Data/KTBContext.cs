using System.Data.Entity.ModelConfiguration.Conventions;
using KTB.Models;

namespace KTB.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KTBContext : DbContext
    {
        public KTBContext()
            : base("name=KTBContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<KTBContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Loans)
                .WithMany(l => l.Employees)
                .Map(el =>
                {
                    el.ToTable("EmployeesLoans");
                    el.MapLeftKey("EmployeeId");
                    el.MapRightKey("LoanId");
                });

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Accounts)
                .WithMany(a => a.Employees)
                .Map(ea =>
                {
                    ea.ToTable("EmployeesAccounts");
                    ea.MapLeftKey("EmployeeId");
                    ea.MapRightKey("AccountId");
                });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
    }
}