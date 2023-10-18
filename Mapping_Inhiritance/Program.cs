using EFCore.DomainModels;
using Mapping_Inheritance;
using Mapping_Inhiritance.Contexts;

namespace Mapping_Inhiritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using CompanyDbContext dbContext = new CompanyDbContext();

            PartTimeEmployee PartTimeEmployee = new PartTimeEmployee()
            {
                Name = "Ahmed",
                Age = 23,
                Address = "Cairo",
                CountOfHours = 23,
                HourRate = 23,

            };


            FullTimeEmployee fullTimeEmployee02 = new FullTimeEmployee()
            {
                Name = "lina",
                Age = 12,
                Address = "cairo",
                Salary = 23000,
                StartDate = DateTime.Now

            };

            CRUDOperations cRUDOperations = new CRUDOperations(dbContext);
            var result = cRUDOperations.GetFullEmployee(1);

            Console.WriteLine(result.Name);
        }
    }
}
