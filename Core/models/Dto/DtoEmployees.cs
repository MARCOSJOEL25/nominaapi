using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;

namespace Core.models.Dto
{
    public class DtoEmployees
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string correo { get; set; }

        public char gender { get; set; }

        public string ImagesUrl { get; set; }

        public DateTime birdDate { get; set; }

        public DateTime DataIn { get; set; } = DateTime.Now;

        public double netSalary { get; set; }
        public double salaryFinal { get; set; }

        public string user { get; set; } 

        public bool isActive { get; set; } = false;

        public string job { get; set; }

        public double Adiccion { get; set; } 
        public int ISR { get; set; } 
        public int AFP { get; set; } 
        public int ARS { get; set; }
    }
}