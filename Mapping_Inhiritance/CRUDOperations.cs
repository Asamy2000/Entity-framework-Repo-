using EFCore.DomainModels;
using Mapping_Inhiritance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mapping_Inheritance
{
    internal class CRUDOperations
    {
        private readonly CompanyDbContext _dbContext;

        public CRUDOperations(CompanyDbContext companyDbContext)
        {
            _dbContext = companyDbContext;
        }

        public void InsertEmployee(EmployeeBase employee)
        {
            try
            {
                _dbContext.Add(employee);
                _dbContext.SaveChanges();
                Console.WriteLine($"{employee.Name} added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                // Handle the exception as needed.
                throw; // Rethrow the exception or handle it appropriately.
            }
        }

        public void UpdateEmployee(EmployeeBase employee)
        {
            try
            {
                _dbContext.Update(employee);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                // Handle the exception as needed.
                throw; // Rethrow the exception or handle it appropriately.
            }
        }

        public void DeleteFullEmployee(int employeeId)
        {
            try
            {
                var employee = _dbContext.Set<FullTimeEmployee>().Find(employeeId);
                if (employee != null)
                {
                    _dbContext.Remove(employee);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                // Handle the exception as needed.
                throw; // Rethrow the exception or handle it appropriately.
            }
        }

        public void DeletePartEmployee(int employeeId)
        {
            try
            {
                var employee = _dbContext.Set<PartTimeEmployee>().Find(employeeId);
                if (employee != null)
                {
                    _dbContext.Remove(employee);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                // Handle the exception as needed.
                throw; // Rethrow the exception or handle it appropriately.
            }
        }
        public FullTimeEmployee GetFullEmployee(int employeeId)
        {
            try
            {
                return _dbContext.Set<FullTimeEmployee>().Find(employeeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw; // Rethrow the exception or handle it appropriately.
            }
        }


        public PartTimeEmployee PartEmployee(int employeeId)
        {
            try
            {
                return _dbContext.Set<PartTimeEmployee>().Find(employeeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                throw; // Rethrow the exception or handle it appropriately.
            }
        }
    }
}
