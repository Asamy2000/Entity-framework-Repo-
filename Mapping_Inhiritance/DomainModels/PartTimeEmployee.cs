using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DomainModels
{
    internal class PartTimeEmployee : EmployeeBase
    {
        public int CountOfHours { get; set; }
        public int HourRate { get; set; }
    }
}
