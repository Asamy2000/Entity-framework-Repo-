using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DomainModels
{
    internal class FullTimeEmployee : EmployeeBase
    {
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
    }
}
