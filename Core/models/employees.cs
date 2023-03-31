using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.models
{
    public class employees
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string correo { get; set; }

        public string birdDate { get; set; }

        public string DataIn { get; set; }

        public int createAt { get; set; }

        public bool isActive { get; set; }

    }
}