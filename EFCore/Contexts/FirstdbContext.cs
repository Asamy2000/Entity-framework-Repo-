using EFCore.Configurations;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Contexts
{
    internal class FirstdbContext : DbContext
    {
        /*
          OnConfiguring Method: The OnConfiguring method is a protected method provided by DbContext that you can 
                                override in your derived context class. It is typically used to configure the database provider, 
                                connection string, and other options. 
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
               // => base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = First; Integrated security = true"));
               => optionsBuilder.UseSqlServer("Server =.; Database = First; Trusted_Connection = true");
        /*
          In this method [OnConfiguring()], you configure the database provider and connection string. 
          This method is called internally when an instance of your context class is created. 
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent API 
            //1. use it when U can't do something with Convention | Data Annotation (Composite PK - configure Relation - identity(10,10))
            //2. use it when U don't have the source code of a model [il]
            //where U can write code using Fluent API [DbContext => override OnModelCtreating]

            // EF Core 3.1 Feature
            //modelBuilder.Entity<Department>(MB =>
            //{

            //});

            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfigurations());
            modelBuilder.ApplyConfiguration(new CourseConfigurations());
            modelBuilder.ApplyConfiguration(new CourseStudentConfigurations());


            #endregion







            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        /*
        indicates that you have a DbSet property named Employees in your DbContext class. 
        Entity Framework Core will use this convention to map the Employee class to a database table named "Employees" 
        by pluralizing the class name according to the default conventions.
        */

        // database status now [database named First with one table called Employee]

        // public DbSet<Department> Departments { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
