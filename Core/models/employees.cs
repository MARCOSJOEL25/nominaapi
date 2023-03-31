using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace core.models
{
    public class employees
    {   
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
        public string correo { get; set; }

        public DateTime birdDate { get; set; }

        public DateTime DataIn { get; set; }

        public int createAt { get; set; }

        public bool isActive { get; set; }

        public int Idjob { get; set; }

        [ForeignKey("Idjob")]
        public job job { get; set; }

    }
}