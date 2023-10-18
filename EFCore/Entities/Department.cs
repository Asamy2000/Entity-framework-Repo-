using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    internal class Department
    {
        public int DeptId { get; set; }
        public string  Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        /// <summary>
           //Navigational prop [Department have many employee]
           //Employees is just reference so when any One Create obj from Department must create obj from Employee
           //so its initialize in CTOR or in the same line of the prop
        /// </summary>
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

     
    }
}
