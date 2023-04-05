using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.models
{
    public class adicción
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public double adicciónSalary { get; set; }

        public string motivo {get; set;}

    }
}