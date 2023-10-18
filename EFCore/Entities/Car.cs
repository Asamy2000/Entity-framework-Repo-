using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    internal class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Employee Employee { get; set; }
    }
}
