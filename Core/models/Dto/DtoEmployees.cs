using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.models;

namespace Core.models.Dto
{
    public class DtoEmployees
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string correo { get; set; }

        public string ImagesUrl { get; set; }

        public DateTime birdDate { get; set; }

        public DateTime DataIn { get; set; } = DateTime.Now;

        public string user { get; set; } 

        public bool isActive { get; set; } = false;

        public string job { get; set; }
    }
}