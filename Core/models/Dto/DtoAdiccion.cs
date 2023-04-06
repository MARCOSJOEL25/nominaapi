using core.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models.Dto
{
    public  class DtoAdiccion
    {
        public int ID { get; set; }

        public int EmployeeId { get; set; }

        public double adicciónSalary { get; set; }

        public string motivo { get; set; } = "";

    }
}
