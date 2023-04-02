using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;

namespace Core.models.Dto
{

    public class DtoEmployeesCreate : Deducciones
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string correo { get; set; }

        public char gender {get; set; }

        public string ImagesUrl { get; set; }

        public DateTime birdDate { get; set; }

        public DateTime DataIn { get; } = DateTime.Now;
        public double netSalary {get; set;}
        public double salaryFinal 
        {
            get
            {
                var salary = salaryFinal - ((salaryFinal * Deducciones.AFP) + (salaryFinal * Deducciones.ASF));

                if(netSalary >= Deducciones.limitISR)
                    return salary - (salaryFinal * Deducciones.ISR);
                return salary;
            }
            
        } 

        public int createAt { get; } = 1;

        public bool isActive { get; set; } = false;

        public int Idjob { get; set; } = 4;

    }
}