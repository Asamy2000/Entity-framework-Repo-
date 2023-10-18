using EFCore.Contexts;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Facts
            /*
             
          -->EntityFrame work is a ORM [object relation mapper]
             object => Class
             relation => table 
             Mapper => converts classes to tables [code first] or tables to classes [DB first]

          -->Mapping Approaches 
             1.Code first => from code [classes] Generate DB(tables,views) (most common used) flexable
             2.DB first   => from DB Generate Classes

          -->After mapping 
              L2E (LINQ TO Entity Frame Work) :: Query Object Model
              Object model => Raw in Table 
              object from class --> Raw in table 

         -->DB Generation (schemas => [TPC - TPH - TPCC])
             TPC [Table Per Class]
               every single Class will converted into table in DB if (Code First)
               every single Table will converted into class in Program (DB first)

             Example : suppose a Compony with Two types of Employees [partTimeEmployee - FullTimeEmployee ]
                       and there is a Common properties for the two types (ID - Name - Age - Address)
                       partTimeEmployee have another properties (HourRate - CountOfHours)
                       FullTimeEmployee have another properties (StartDate - Salary)

              lets code that

         abstract class Employee
         {
             //Container for the common props
             //abstract to prevent Object Creation because it is not exist in real
             //just two types [partTimeEmployee - FullTimeEmployee]
             public int Id { get; set; }
             public string Name { get; set; }
             public int Age { get; set; }
             public string Address { get; set; }
         }

         class PartTimeEmployee : Employee
         {
             public decimal HourRate { get; set; }
             public int CountOfHours { get; set; }
         }

         class FullTimeEmployee : Employee
         {
             public DateOnly StartDate { get; set; }
             public decimal Salary { get; set; }
         }

             -->According to [TPC] : each class will mapped to table 

             Employee(Id , Name , Age , Address) -->Id Pk
             PartTimeEmployee(PartEmpId,HourRate , CountOfHours) -->PartEmpId => FK references Id
             FullTimeEmployee(FullEmpId,StartDate , Salary) -->FullEmpId => FK references Id


             --> CRUD Operations will be applied every time on two tables at least 
                 joins - Performance is not the best 
            


             TPH [table per Hierarchy]
             all of the Hierarchy mapped into one table 
             Employee(Id , Name , Age , Address,HourRate , CountOfHours,StartDate , Salary , Discriminator )
             --> Discriminator => is a column to distinguish if the Employee is a PartTimeEmployee | FullTimeEmployee
            
             CRUD Operations will be applied on one table 
             No joins - Good performance!

             when You insert a PartTimeEmployee the values of FullTimeEmployee (StartDate , Salary) will be null
             and the same problem when You insert a FullTimeEmployee
            
             if FullTimeEmployee => PartTimeEmployee values [null]
             if PartTimeEmployee => FullTimeEmployee values [null]

             --> So we have the Null problem
                 Reserve a place in memory without using it


            TPCC [Table Per Concrete Class]
            Concrete Classes => table exists in the real world 

            #region Concrete Class
            Concrete Class: A concrete class in object-oriented programming is a class that provides a complete and tangible
                            implementation of its attributes (fields), behaviors (methods), and properties. 
                            Objects of a concrete class can be created directly, and they represent real-world entities
                            or concepts with specific characteristics and functionality.
            #endregion

            So Employee is not Concrete Class 
            while 
            PartTimeEmployee & FullTimeEmployee are Concrete Classes

             PartTimeEmployee(Id , Name , Age , Address , HourRate , CountOfHours) 
             FullTimeEmployee(Id , Name , Age , Address , StartDate , Salary) 




            */
            #endregion
            #region instance from FirstdbContext 
            //FirstdbContext dbContext = new FirstdbContext();/* parameter less ctor */
            //parameter less ctor chain on the parameter less ctor of the parent [DbContext] which call OnConfiguring();
            //Dynamic | run time polymorphism [dynamic binding]
            //CLR will execute the last override OnConfiguring() which is dynamic binding method;
            /*
              Dynamic Binding (Polymorphism): The concept of dynamic binding or runtime polymorphism refers to the behavior where
                                              the appropriate method (in this case, OnConfiguring) is determined 
                                              and executed at runtime based on the actual type of the object.
                                              In C#, this is a fundamental aspect of object-oriented programming.
              When you create an instance of your FirstdbContext class, the OnConfiguring method of FirstdbContext (if overridden)
              will be executed. If FirstdbContext doesn't override the OnConfiguring method, then the one in its base class (DbContext)
              will be executed. 
            */

            /*
             in Summary
             The parameterless constructor chains to the parent constructor, and the OnConfiguring method is called at runtime
             to configure the database connection based on the actual derived context class being used. This is an example of 
             dynamic binding in action, where the method executed depends on the specific instance's type.
            */
            #endregion

            #region Migration

            //simple description for Migration class
            /*

             class Migration 
             {
               //to applying change on database
               Up();
               //to rollback the change 
               Down();
             } 
              
             **to remove migration you must execute Down(); first to 
               ensures that your database remains consistent with the expected schema described in your code
                   how to execute Down(); => update-database -Migration "migration01" which is created befoure my migration02 
                   

                   what if i needs to remove first migration
                             -->Update-database 0

            //commands
              --> Add-Migration "MigrationName"
                   first migration usually named "initialCreate"
              --> Update-Database
                   to apply migrations
              --> Update-database -Migration "migration01" which is created befoure my migration02
              --> Update-database 0 (Rollback first migration)
            */

            #region snaphot class
            /*


              "snapshot class" refers to a class that is generated and stored in the Migrations folder of your project
               when you create database migrations. This class is part of the migration process and plays a crucial role 
               in managing and updating your database schema
               
                *************Here's what the snapshot class does********* 

                1.Database Schema Representation: The snapshot class is automatically generated by EF Core based on your entity classes 
                                                  and their configurations. It represents a snapshot of the current state of your database 
                                                  schema at a specific point in time.

                2.Database Schema History: The snapshot class is used to keep track of changes to your database schema over time. 
                                           Each migration (e.g., when you add a new table or modify an existing one) is associated with 
                                           a specific snapshot class that captures the schema at that migration's point in time.

                3.Comparison During Migrations: When you apply a new migration, EF Core compares the current database schema to the schema 
                                                defined in the snapshot class associated with that migration. 
                                                It generates SQL scripts to update the database schema to match the expected 
                                                schema defined in the migration.

                3.Maintaining Database Consistency: The snapshot class ensures that your database remains consistent with the expected schema 
                                                    described in your code, even as your application evolves and new migrations are applied.                






             */
            #endregion
            //execute every UP() function which is not applied
            //Applying Migration by code
            //dbContext.Database.Migrate();
            #endregion

            #region fluent APi

            //dbContext.Set<Department>(); //valid 
            //dbContext.Department.Add(new Department()); //notValid because the is no DBSet<Departments> 
            #endregion


            #region CRUD Operations
            //try
            //{
            //    //CRUD Operations
            //}
            //finally
            //{
            //    //Dispose | Delete DB Connection
            //    // because it is not Under the control of CLR
            //    dbContext.Dispose();
            //}

            //new feature in C# 7.0 
            //using (FirstdbContext dbContext = new FirstdbContext()) //syntax Sugar --> TRY Finally
            //{
            //    //CRUD Operations
            //}

            //another syntax Sugar
            using FirstdbContext dbContext = new FirstdbContext();
            #region INsertion
            //Employee employee01 = new Employee()
            //{
            //    Name = "ahmed",
            //    Age = 20,
            //    Salary = 20,
            //    Email = "ahmed@gmail.com",
            //    Password = "password",
            //    PhoneNumber = "1234567890"

            //};
            //Employee employee02 = new Employee()
            //{
            //    Name = "lina",
            //    Age = 12,
            //    Salary = 20,
            //    Email = "lina@gmail.com",
            //    Password = "password",
            //    PhoneNumber = "1234567890"

            //};

            //Console.WriteLine(dbContext.Entry(employee02).State); //Deatached
            //// insertion
            ////dbContext.Employees.Add(employee01);
            ////dbContext.Set<Employee>().Add(employee02);
            ////Add to local
            //dbContext.Add(employee01);  //Ef core 3.1 feature
            //dbContext.Add(employee02);
            //Console.WriteLine(dbContext.Entry(employee02).State); //Added

            ////dbContext.Entry(employee01).State = EntityState.Added;

            //dbContext.SaveChanges(); //to Add remote [in Database]

            //Console.WriteLine(dbContext.Entry(employee02).State); //Unchanged

            //Console.WriteLine("-----------------");
            //Console.WriteLine(employee01.EmpId);
            //Console.WriteLine(employee02.EmpId); 
            #endregion
            /* ObjectStates
              dbContext.Entry(employee01).State;

              /// <summary>
              ///     The entity is not being tracked by the context.
              /// </summary>
              Detached = 0,

              /// <summary>
              ///     The entity is being tracked by the context and exists in the database. Its property
              ///     values have not changed from the values in the database.
              /// </summary>
              Unchanged = 1,

              /// <summary>
              ///     The entity is being tracked by the context and exists in the database. It has been marked
              ///     for deletion from the database.
              /// </summary>
              Deleted = 2,

              /// <summary>
              ///     The entity is being tracked by the context and exists in the database. Some or all of its
              ///     property values have been modified.
              /// </summary>
              Modified = 3,

              /// <summary>
              ///     The entity is being tracked by the context but does not yet exist in the database.
              /// </summary>
              Added = 4

            */


            #region Retrieve - Update - Delete
            //var emp = dbContext.Employees.AsNoTracking().FirstOrDefault(); 
            //// if U just want to retrieve Employees no [Update | Delete]
            ///  so disable Change tracker



            //emp = (from E in dbContext.Employees
            //       select E).FirstOrDefault();

            //emp = (from E in dbContext.Employees
            //       where E.EmpId == 1
            //       select E).FirstOrDefault();
            var emp = dbContext.Employees.FirstOrDefault();
            ////all of this blocks of code returns IEnumerable<Employee> so I use FirstOrDefault() operator to select first emp in the list

            //Console.WriteLine(emp?.Name ?? "NA");
            //Console.WriteLine(dbContext.Entry(emp)?.State ); //Unchanged

            ////Update
            //emp.Name = "ahmed";
            //Console.WriteLine(emp?.Name ?? "NA");
            //Console.WriteLine(dbContext.Entry(emp)?.State); //Modified

            //delete
            //dbContext.Employees.Remove(emp);
            //dbContext.SaveChanges()

            #endregion
            #endregion
        }


    }
}
