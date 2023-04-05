using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Utils;
using Core.models;

namespace core.models
{
    public class employees 
    {   
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string correo { get; set; }

        public char gender {get; set; }

        public string ImagesUrl { get; set; }

        public DateTime birdDate { get; set; }

        public DateTime DataIn { get; set; }

        public double netSalary {get; set;}
        public double salaryFinal {get; set;}
        public int createAt { get; set; } 

        [ForeignKey("createAt")]
        public user user { get; set; } 

        public bool isActive { get; set; }

        public int Idjob { get; set; }

        [ForeignKey("Idjob")]
        public job job { get; set; }

        public int IdAdiccion { get; set; }

        [ForeignKey("IdAdiccion")]
        public adicción adicción { get; set; }
    }
}