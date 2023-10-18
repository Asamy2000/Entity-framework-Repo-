using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> MB)
        {
            MB
              .ToTable("Departments"/*,"Schema"*/)
              //.ToView("Depts") //how to link it with View
              //.HasKey("DeptId"); //set PK i passes it as string if no prop in the code but the is col in DB
              //.HasKey(nameof(Department.DeptId)); //set PK
              .HasKey(D => D.DeptId); //set PK

            MB
            .Property(D => D.DeptId) /*to get prop*/
            .UseIdentityColumn(); /*to set identity(1,1)*/
            //.UseIdentityColumn(10,10); /*to set identity(10,10)*/

            MB
            .Property(D => D.Name) /*to get prop*/
            .HasColumnName("DeptName")
            .HasColumnType("varChar")
            .HasDefaultValue("dept")
            .HasMaxLength(100)
            .IsRequired(false);
            //.HasAnnotation("MaxLength", "50");  /* to use DataAnnotation */

            MB
            .Property(D => D.DateOfCreation)
            .HasDefaultValueSql("GETDATE()");

            MB
             .HasMany(D => D.Employees)
             .WithOne(E => E.Department)
             .HasForeignKey(E => E.DepartmentDeptId)
             .IsRequired(false)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
