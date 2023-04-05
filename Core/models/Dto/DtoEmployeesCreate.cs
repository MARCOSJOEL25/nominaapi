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

        public char gender { get; } = 'M';

        public string ImagesUrl { get; } = "";

        public DateTime birdDate { get; } = DateTime.Now;

        public DateTime DataIn { get; } = DateTime.Now;

        public double netSalary {get; set;}
        public double salaryFinal {get; } = 0;

        public int createAt { get; } = 1;
        public bool isActive { get;} = true;

        public int Idjob { get; } = randomJob();

        private static int randomJob()
        {
            int min = 1;
            int max = 12;

            Random rnd = new Random();
            return rnd.Next(min, max + 1);
        }
    }
}