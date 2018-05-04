namespace Employees
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesProject> EmployeesProjects { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Town> Towns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.AddressText)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Subordinates)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.ManagerID);

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Town>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
