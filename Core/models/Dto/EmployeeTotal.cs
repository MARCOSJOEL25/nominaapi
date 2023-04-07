using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models.Dto
{
    public class EmployeeTotal
    {
        public int total { get; set; }
        public Object active { get; set; }

        public Object inactive { get; set; }
    }
}
