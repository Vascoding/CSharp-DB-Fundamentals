using AdvancedMapping.Models;

namespace Projection
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProjectionContext : DbContext
    {
        
        public ProjectionContext()
            : base("name=ProjectionContext")
        {
        }

       public virtual DbSet<Employee> Employees { get; set; }
    }

  
}