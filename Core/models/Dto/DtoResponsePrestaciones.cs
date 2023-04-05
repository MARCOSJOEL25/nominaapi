using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models.Dto
{
    public class DtoResponsePrestaciones
    {
        public string NombreEmpleado { get; set; }

        public string TiempoEmpresa { get; set; }
        public double PrestacionesTotales { get; set; }
        public double salarioDelEmpleado { get; set; }
    }
}
