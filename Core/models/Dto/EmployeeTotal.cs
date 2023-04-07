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

        public int totalactive { get; set; }

        public int totalinactive { get; set; }


        public object active { get; set; }

        public object inactive { get; set; }

        public int totalPages { get; set; }
        public int Page { get; set; }
    }
}
