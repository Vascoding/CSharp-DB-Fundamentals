using CodeFirstStudentSystem.Migrations;
using CodeFirstStudentSystem.Models;

namespace CodeFirstStudentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentContext : DbContext
    {
        // Your context has been configured to use a 'StudentContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirstStudentSystem.StudentContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentContext' 
        // connection string in the application configuration file.
        public StudentContext()
            : base("name=StudentContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
    }
}