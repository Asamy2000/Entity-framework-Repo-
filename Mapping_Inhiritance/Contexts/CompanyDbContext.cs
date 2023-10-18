using EFCore.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_Inhiritance.Contexts
{
    internal class CompanyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseSqlServer("Server =.; Database = CompanyDb02; Trusted_Connection = true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TPH [Table per Hierarchy ] the Hierarchy mapped into one Table and EF Core add [Discriminator]
            //modelBuilder.Entity<FullTimeEmployee>().HasBaseType(typeof(EmployeeBase));
            //modelBuilder.Entity<PartTimeEmployee>().HasBaseType(typeof(EmployeeBase));

            base.OnModelCreating(modelBuilder);
        }

        //TPCC [Table per Concrete Class] DbSet for concrete Classes [Recommended]

        DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }


        


    }
}
