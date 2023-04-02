using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;

namespace Core.models.Dto
{

    public class DtoEmployeesCreate 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string correo { get; } = "example@gmail.com";

        public char gender {get; set; }

        public string ImagesUrl { get; } = "";

        public DateTime birdDate { get; } = DateTime.Now;

        public DateTime DataIn { get; } = DateTime.Now;

        public double netSalary {get; set;}
        public double salaryFinal {get; } = 0;

        public int createAt { get; } = 1;
        public bool isActive { get;} = true;

        public int Idjob { get; } = 1;
    }
}