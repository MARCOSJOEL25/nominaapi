using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.models
{
    public class adicción
    {
        public int ID { get; set; } 
        public int EmployeeId { get; set; }

        public double adicciónSalary { get; set; }

        public string motivo {get; set;}

    }
}