using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    internal class Staff:Passenger
    {
        public string Function { get; set; }
        public DateTime EmployementDate { get; set; }
        public double Salary { get; set; }
    }
}
